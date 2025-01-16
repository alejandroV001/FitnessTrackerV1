﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using WorkoutService;

#nullable disable

namespace WorkoutService.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20250115224429_InitialCreateWorkout")]
    partial class InitialCreateWorkout
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("WorkoutService.Models.Exercise", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("MuscleGroupId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("MuscleGroupId");

                    b.ToTable("Exercises");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            MuscleGroupId = 1,
                            Name = "Bench Press"
                        },
                        new
                        {
                            Id = 2,
                            MuscleGroupId = 1,
                            Name = "Incline Dumbbell Press"
                        },
                        new
                        {
                            Id = 3,
                            MuscleGroupId = 2,
                            Name = "Pull Ups"
                        },
                        new
                        {
                            Id = 4,
                            MuscleGroupId = 2,
                            Name = "Deadlift"
                        },
                        new
                        {
                            Id = 5,
                            MuscleGroupId = 3,
                            Name = "Squat"
                        },
                        new
                        {
                            Id = 6,
                            MuscleGroupId = 3,
                            Name = "Bulgarian Splits"
                        },
                        new
                        {
                            Id = 7,
                            MuscleGroupId = 4,
                            Name = "Bicep Curl"
                        },
                        new
                        {
                            Id = 8,
                            MuscleGroupId = 4,
                            Name = "Tricep Extension"
                        },
                        new
                        {
                            Id = 9,
                            MuscleGroupId = 5,
                            Name = "Overhead Shoulder Press"
                        },
                        new
                        {
                            Id = 10,
                            MuscleGroupId = 5,
                            Name = "Lateral Raises"
                        },
                        new
                        {
                            Id = 11,
                            MuscleGroupId = 6,
                            Name = "Plank"
                        },
                        new
                        {
                            Id = 12,
                            MuscleGroupId = 6,
                            Name = "Russian Twists"
                        });
                });

            modelBuilder.Entity("WorkoutService.Models.MuscleGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("MuscleGroups");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Chest"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Back"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Legs"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Arms"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Shoulders"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Core"
                        });
                });

            modelBuilder.Entity("WorkoutService.Models.Workout", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("DurationMinutes")
                        .HasColumnType("integer");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Workouts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Date = new DateTime(2025, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DurationMinutes = 60,
                            UserId = 1
                        },
                        new
                        {
                            Id = 2,
                            Date = new DateTime(2025, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DurationMinutes = 45,
                            UserId = 1
                        },
                        new
                        {
                            Id = 3,
                            Date = new DateTime(2025, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DurationMinutes = 30,
                            UserId = 2
                        },
                        new
                        {
                            Id = 4,
                            Date = new DateTime(2025, 1, 13, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DurationMinutes = 90,
                            UserId = 2
                        });
                });

            modelBuilder.Entity("WorkoutService.Models.WorkoutExercise", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("ExerciseId")
                        .HasColumnType("integer");

                    b.Property<int>("Reps")
                        .HasColumnType("integer");

                    b.Property<int>("Sets")
                        .HasColumnType("integer");

                    b.Property<float>("WeightKg")
                        .HasColumnType("real");

                    b.Property<int>("WorkoutId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ExerciseId");

                    b.HasIndex("WorkoutId");

                    b.ToTable("WorkoutExercises");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ExerciseId = 1,
                            Reps = 10,
                            Sets = 3,
                            WeightKg = 50f,
                            WorkoutId = 1
                        },
                        new
                        {
                            Id = 2,
                            ExerciseId = 3,
                            Reps = 8,
                            Sets = 4,
                            WeightKg = 0f,
                            WorkoutId = 1
                        },
                        new
                        {
                            Id = 3,
                            ExerciseId = 5,
                            Reps = 6,
                            Sets = 5,
                            WeightKg = 80f,
                            WorkoutId = 2
                        },
                        new
                        {
                            Id = 4,
                            ExerciseId = 6,
                            Reps = 10,
                            Sets = 4,
                            WeightKg = 25f,
                            WorkoutId = 2
                        },
                        new
                        {
                            Id = 5,
                            ExerciseId = 7,
                            Reps = 12,
                            Sets = 3,
                            WeightKg = 15f,
                            WorkoutId = 3
                        },
                        new
                        {
                            Id = 6,
                            ExerciseId = 8,
                            Reps = 12,
                            Sets = 3,
                            WeightKg = 20f,
                            WorkoutId = 3
                        },
                        new
                        {
                            Id = 7,
                            ExerciseId = 9,
                            Reps = 8,
                            Sets = 4,
                            WeightKg = 40f,
                            WorkoutId = 4
                        },
                        new
                        {
                            Id = 8,
                            ExerciseId = 11,
                            Reps = 1,
                            Sets = 3,
                            WeightKg = 0f,
                            WorkoutId = 4
                        });
                });

            modelBuilder.Entity("WorkoutService.Models.Exercise", b =>
                {
                    b.HasOne("WorkoutService.Models.MuscleGroup", "MuscleGroup")
                        .WithMany("Exercises")
                        .HasForeignKey("MuscleGroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MuscleGroup");
                });

            modelBuilder.Entity("WorkoutService.Models.WorkoutExercise", b =>
                {
                    b.HasOne("WorkoutService.Models.Exercise", "Exercise")
                        .WithMany()
                        .HasForeignKey("ExerciseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WorkoutService.Models.Workout", "Workout")
                        .WithMany("WorkoutExercises")
                        .HasForeignKey("WorkoutId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Exercise");

                    b.Navigation("Workout");
                });

            modelBuilder.Entity("WorkoutService.Models.MuscleGroup", b =>
                {
                    b.Navigation("Exercises");
                });

            modelBuilder.Entity("WorkoutService.Models.Workout", b =>
                {
                    b.Navigation("WorkoutExercises");
                });
#pragma warning restore 612, 618
        }
    }
}
