Overview
The project simulates an event system for students, where different services can react when a new student is added.
The core of the project is the StudentEventBroker, which manages subscriptions and publication of student-related events.


--- Main Components
1. Student
Simple class representing a student, with properties such as Name.

2. Student Event Broker
• Manages student addition events.
• Allows other services to subscribe to be notified when a student is added.
• Uses an associated delegate (OnStudentAdded) to allow methods that return ValueTask<Student>.
• When a student is added, calls all subscribed methods via PublishAsync.

3. PAStudentService
• Service that does not log any student addition events.
• When notified, executes the CreateStudentPARecordAsync method, which prints a lowercase message that the student's PA record has been created.

4. StudentService and StudentLibraryService
• Additional services that can subscribe to the event, each with its own logic when receiving a new student.
• Examples: creating records, updating libraries, etc.

5. Program.cs
• Project entry point.
• Creates instances of the services and the StudentEventBroker.
• Add services to the events.
• Adds students and publishes the event, triggering the actions of the subscribed services.


---
Workflow
1. Initialization:
The program initializes the StudentEventBroker and the services.

2. Event Subscription:
Each service is registered in the student addition event, indicating which method should be called when the event occurs.

3. Event Publication:
When a student is added (for example, via PublishAsync), the StudentEventBroker calls all subscribed methods, allowing each service to execute its logic.

4. Execution of Actions:
Each service performs its specific action (e.g., create PA record, update library, etc.) and can return the processed student.


--- Visual Summary
[Program]
|
v
[StudentEventBroker] <--- Services subscribe (Subscribe)
|
v
[Services: PAStudentService, StudentService, StudentLibraryService]
|
v When a student is added:
-> All subscribed services are notified and execute their actions

Objective
This project demonstrates how to implement an event pattern (Event Broker) in C#, allowing multiple services to react in a decoupled way to the addition of students.