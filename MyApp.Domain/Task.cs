﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Domain
{
    public class Task
    {
        public Guid Id { get; set; }

        [MaxLength(255)]
        public string Title { get; set; }

        [MaxLength(255)]
        public string Description { get; set; }

        public DateTime? DueDate { get; set; }

        public TaskPriority Priority { get; set; }
        public bool IsCompleted { get; set; }

        public DateTime CreationDate { get; set; }

        public Task()
        {
        }

        public Task(Guid id, string title)
        {
            Id = id;
            Title = title;

            Priority = TaskPriority.Medium;
            CreationDate = Clock.Now();
            DueDate = Clock.Now().AddDays(1);
            IsCompleted = false;
        }

        public void Complete()
        {
            if (IsCompleted)
                throw new InvalidOperationException("Task is already completed");

            IsCompleted = true;
        }

        public void IncreasePriority()
        {
            if (IsCompleted)
                throw new InvalidOperationException("Task is already completed and cannot be changed");

            if (Priority == TaskPriority.Low)
                Priority = TaskPriority.Medium;
            else if (Priority == TaskPriority.Medium)
                Priority = TaskPriority.High;
            else if (Priority == TaskPriority.High)
                throw new InvalidOperationException("Task has already the highest priority");
        }

        public void DecreasePriority()
        {
            if (IsCompleted)
                throw new InvalidOperationException("Task is already completed and cannot be changed");

            if (Priority == TaskPriority.Low)
                throw new InvalidOperationException("Task has already the lowest priority");
            else if (Priority == TaskPriority.Medium)
                Priority = TaskPriority.Low;
            else if (Priority == TaskPriority.High)
                Priority = TaskPriority.Medium;
        }

        public void SetDueDate(DateTime dateTime)
        {
            DueDate = dateTime;
        }
    }
}
