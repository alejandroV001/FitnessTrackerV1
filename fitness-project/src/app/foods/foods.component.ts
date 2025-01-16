import { Component, OnInit } from '@angular/core';
import { FoodsService } from '../foods.service';

@Component({
  selector: 'app-foods',
  templateUrl: './foods.component.html',
  styleUrls: ['./foods.component.css']
})
export class FoodsComponent implements OnInit {
  foods: any[] = []; 
  selectedFood: any = {};
  isEditing: boolean = false;
  openModal:boolean = false;

  constructor(private foodsService: FoodsService) {}

  ngOnInit(): void {
    this.loadFoods();
  }

  exit(): void {
    this.openModal = false;
    this.selectedFood = null;
  }

  loadFoods(): void {
    this.foodsService.getFoods().subscribe(
      (data) => {
        this.foods = data;
      },
      (error) => {
        console.error('Error loading foods', error);
      }
    );
  }

  openAddFoodModal(): void {
    this.openModal = true;
    this.selectedFood = {};
    this.isEditing = false;
    console.log('Open modal to add new food');
  }

  openEditFoodModal(food: any): void {
    this.selectedFood = { ...food };
    this.openModal = true;
    this.isEditing = true;

    console.log(`Open modal to edit food with ID: ${food.id}`);
  }


  addFood(): void {
    this.foodsService.addFood(this.selectedFood).subscribe(
      (data) => {
        this.foods.push(data);
        this.loadFoods();
        console.log('Food added successfully');
      },
      (error) => {
        console.error('Error adding food', error);
      }
    );
  }

  updateFood(): void {
    this.foodsService.updateFood(this.selectedFood.id, this.selectedFood).subscribe(
      () => {
        const index = this.foods.findIndex(food => food.id === this.selectedFood.id);
        if (index !== -1) {
          this.foods[index] = this.selectedFood;
        }
        console.log('Food updated successfully');
      },
      (error) => {
        console.error('Error updating food', error);
      }
    );
  }

  deleteFood(foodId: number): void {
    this.foodsService.deleteFood(foodId).subscribe(
      () => {
        this.foods = this.foods.filter(food => food.id !== foodId);
        console.log('Food deleted successfully');
      },
      (error) => {
        console.error('Error deleting food', error);
      }
    );
  }
}
