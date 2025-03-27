# School Project: Error Diagnosis with Seq and Zipkin

This repository contains the code for a school project where the task is to find and resolve an error in the code, utilizing **Logging** and **Tracing**.


### Tools and Technologies Used

- **Seq** for logging

- **Zipkin** for tracing

- **ASP.NET** for the backend server

- **Class Library in C#** for backend monitoring
  
- **HTML**, **CSS**, and **JavaScript** for the frontend web application


### Objective

The goal of this project is to:

- Produce an error

- Log relevant information using **Seq**

- Trace activities using **Zipkin**

- Diagnose the unknown error


### Error Location

The error is located in the `PlanetService.cs` class, specifically within the `GetPlanet` method. 

The issue occurs when the method tries to access an invalid index in one of the collections, leading to an **out-of-bound exception**.
