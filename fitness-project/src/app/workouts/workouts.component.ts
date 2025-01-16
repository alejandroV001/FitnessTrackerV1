import { Component, OnInit } from '@angular/core';
import { WorkoutsService } from '../workouts.service';

@Component({
  selector: 'app-workouts',
  templateUrl: './workouts.component.html',
  styleUrls: ['./workouts.component.css']
})
export class WorkoutsComponent implements OnInit {
  muscleGroups: any[] = [];
  selectedMuscleGroup: any = null;
  isEditing = false;
  isModalOpen = false;

  constructor(private workoutsService: WorkoutsService) {}

  ngOnInit(): void {
    this.loadMuscleGroups();
  }

  loadMuscleGroups(): void {
    this.workoutsService.getMuscleGroups().subscribe((data) => {
      this.muscleGroups = data;
    });
  }

  openAddMuscleGroupModal(): void {
    this.selectedMuscleGroup = { name: '' };
    this.isEditing = false;
    this.isModalOpen = true;
  }

  addMuscleGroup(): void {
    const newMuscleGroup = { name: this.selectedMuscleGroup.name };
    this.workoutsService.addMuscleGroup(newMuscleGroup).subscribe((response) => {
      console.log('Muscle group added:', response);
      this.loadMuscleGroups();
      this.closeModal();
    });
  }

  openEditMuscleGroupModal(muscleGroup: any): void {
    this.selectedMuscleGroup = { ...muscleGroup };
    this.isEditing = true;
    this.isModalOpen = true;
  }

  updateMuscleGroup(): void {
    const updatedMuscleGroup = { name: this.selectedMuscleGroup.name };
    this.workoutsService.updateMuscleGroup(this.selectedMuscleGroup.id, updatedMuscleGroup).subscribe((response) => {
      console.log('Muscle group updated:', response);
      this.loadMuscleGroups();
      this.closeModal();
    });
  }

  deleteMuscleGroup(id: number): void {
    this.workoutsService.deleteMuscleGroup(id).subscribe(() => {
      console.log('Muscle group deleted');
      this.loadMuscleGroups();
    });
  }

  closeModal(): void {
    this.isModalOpen = false;
    this.selectedMuscleGroup = null;
  }
}
