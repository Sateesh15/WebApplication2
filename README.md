# WebApplication2
# Task Management API
# This API provides endpoints for managing tasks in a to-do list. It allows users to perform various operations such as retrieving tasks, adding new tasks, updating task details, marking tasks as complete or incomplete, and deleting tasks.
# Endpoints
# Get Tasks
# GET /api/Task
# Retrieve a list of all tasks.
# Response:

# Status Code: 200 OK
# Body: Array of TodoTask objects representing tasks.
# Headers: X-Total-Count indicates the total number of tasks.
# Get Task by ID
# GET /api/Task/{id}
# Retrieve details of a specific task by its ID.

# Parameters:

# id (integer): ID of the task to retrieve.
# Response:

# Status Code: 200 OK
# Body: TodoTask object representing the task.
# Add New Task
# POST /api/Task
# Create a new task.
# Request Body:

# TodoTask object representing the task to be created.
# Response:

# Status Code: 201 Created
# Body: TodoTask object representing the created task.
# Headers: Location header indicates the URL of the newly created task.
# Update Task
# PUT /api/Task/{id}
# Update details of an existing task.

# Parameters:

# id (integer): ID of the task to update.
# Request Body:

# TodoTask object representing the updated task details.
# Response:

# Status Code: 204 No Content
# Delete Task
# DELETE /api/Task/{id}
# Delete a task by its ID.

# Parameters:

# id (integer): ID of the task to delete.
# Response:

# Status Code: 204 No Content
# Complete Task
# PATCH /api/Task/{id}/complete
# Mark a task as complete.

# Parameters:

# id (integer): ID of the task to mark as complete.
# Response:

# Status Code: 200 OK
# Body: TodoTask object representing the updated task.
# Incomplete Task
# PATCH /api/Task/{id}/incomplete
# Mark a task as incomplete.

# Parameters:

# id (integer): ID of the task to mark as incomplete.
# Response:

# Status Code: 200 OK
# Body: TodoTask object representing the updated task.
# Data Model
# TodoTask
# Represents a task in the to-do list.
# Id (integer): Unique identifier for the task.
# Title (string): Title or name of the task.
# Description (string): Description or details of the task.
# DueDate (DateTime): Due date for the task.
# Completed (boolean): Indicates whether the task is completed or not.

# Examples
# Get All Tasks

# GET /api/Task

# Get Task by ID

# GET /api/Task/1

# Add New Task

# POST /api/Task

# Content-Type: application/json

# {
 #  "Title": "Sample Task",
 # "Description": "This is a sample task.",
 # "DueDate": "2024-02-29"
# }

# Update Task

# PUT /api/Task/1
# Content-Type: application/json

# {
  # "Title": "Updated Task Title",
  # "Description": "Updated task description.",
  # "DueDate": "2024-03-15"
# }
# Delete Task

# DELETE /api/Task/1

# Complete Task

# PATCH /api/Task/1/complete

# Incomplete Task

# PATCH /api/Task/1/incomplete
