# Contract Monthly Claim System (CMCS)

![Language](https://img.shields.io/badge/language-C%23-blueviolet)
![Framework](https://img.shields.io/badge/framework-.NET-blue)
![Database](https://img.shields.io/badge/database-Azure%20SQL-orange)
![Status](https://img.shields.io/badge/status-In%20Development-yellow)

A robust web-based application designed to streamline the monthly contract claims process for lecturers. This system, built for the PROG6212 module, provides an intuitive interface for lecturers to log hours and for academic managers to review and approve claims efficiently.

## Table of Contents
* [Introduction](#introduction)
* [Key Features](#key-features)
* [Technology Stack](#technology-stack)
* [Database Design](#database-design)
* [Installation](#installation)
* [Usage](#usage)
* [Contact](#contact)

---

## Introduction

The **Contract Monthly Claim System (CMCS)** solves the administrative challenge of managing monthly claims for contract lecturers. It replaces manual or disjointed processes with a centralized, user-friendly platform. The application is built using ASP.NET MVC, follows the Model-View-Controller architecture, and is backed by a scalable Azure SQL database. The front-end is designed to be responsive and accessible across various device sizes.

---

## Key Features

* **User Authentication**: Secure login for Lecturers, Programme Coordinators, and Academic Managers.
* **Claim Submission**: Lecturers can easily create, submit, and track their monthly claims, detailing hours worked and hourly rates.
* **Approval Workflow**: A streamlined process for Programme Coordinators and Academic Managers to review, approve, or reject claims.
* **Data Management**: Centralized storage and management of all claims, user data, and related information.
* **Responsive UI**: A clean and intuitive user interface designed with Figma and built to adapt to different screen sizes.

---

## Technology Stack

This project leverages a modern, robust tech stack to ensure scalability and maintainability:

* **Backend**: C# with ASP.NET MVC
* **Database**: Azure SQL
* **UI/UX Design**: Figma
* **Architecture**: Entity Framework, Model-View-Controller (MVC)

---

## Database Design

The database is structured using an Entity-Relationship model, where C# models directly map to Azure SQL tables. This approach leverages the power of Entity Framework for seamless data access and manipulation. The core entities include:

* **Lecturer**: Stores personal details and credentials.
* **Claim**: Contains all information about a specific claim, including hours, rates, and status.
* **ProgrammeCoordinator**: Manages assigned lecturers and reviews claims.
* **AcademicManager**: Holds final approval authority over claims.

Below is the Entity-Relationship Diagram (ERD) for the system.

<img width="1582" alt="Entity-Relationship Diagram for the Contract Monthly Claim System" src="https://github.com/user-attachments/assets/d353f8ae-7d5e-415c-8f22-37b125a4cffe" />

---

## Project Plan

<img width="3242" height="1196" alt="Project Outline" src="https://github.com/user-attachments/assets/a8d3b1f8-c407-4ee4-b5ea-34b43daccc36" />

---

## UI Mockup

Lecturer Dashboard
<img width="1342" height="1113" alt="LecturerDashboard" src="https://github.com/user-attachments/assets/0246ef99-1654-40c0-8428-aa209b6d8f29" />

Administrator Dashboard
<img width="1315" height="1166" alt="Dashboard" src="https://github.com/user-attachments/assets/f88de976-0a32-4c74-9553-90e0a6ce26b1" />

Administrator Approvals Page
<img width="1501" height="1284" alt="Claims" src="https://github.com/user-attachments/assets/b69d4079-8edc-4e37-9c68-c0a4d628f717" />

New Claim Form
<img width="1261" height="1117" alt="NewClaim" src="https://github.com/user-attachments/assets/d16884f0-f49d-497a-9f83-7e2c360c8eb6" />

Figma Design Link
https://www.figma.com/design/Dh0Lc40pfZePsIY8HC6joI/CMCS-POE?node-id=0-1&t=wjscumqRIK5OCFyM-1

---

## Installation

To get a local copy up and running, follow these simple steps.

1.  **Prerequisites**
    * .NET SDK (Version X.X.X)
    * Visual Studio 2022 or later
    * An Azure SQL instance or local SQL Server
2.  **Clone the repo**
    ```sh
    git clone [https://github.com/VCCT-PROG6212-2025-G3/CMCS-ST10434047.git](https://github.com/your_username/CMCS-ST10434047.git)
    ```
3.  **Configure the database**
    * Open `appsettings.json`.
    * Update the `ConnectionString` with your database credentials.
4.  **Run the application**
    * Open the solution in Visual Studio and press `F5` to build and run the project.

---

## Usage

**Coming Soon**

---

## Contact

*Jamie Abrahams* - *st10434047@vcconnect.edu.za*
ST10434047

Project Link: [https://github.com/VCCT-PROG6212-2025-G3/CMCS-ST10434047](https://github.com/your_username/CMCS-ST10434047)
