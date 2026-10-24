# Unified Document Viewer

## Overview

Unified Document Viewer is a .NET-based solution that enables users to search for vehicle-related documents using a Vehicle Identification Number (VIN).

The solution consists of two applications:

1. **UnifiedDocumentViewer** (UI Application)
   - ASP.NET Core MVC/Razor Pages application
   - Provides the user interface for VIN search
   - Calls the backend API to retrieve documents

2. **UnifiedDocumentViewerAPI** (Backend API)
   - ASP.NET Core Web API
   - Aggregates document data from multiple mocked systems
   - Reads data from JSON files
   - Returns a unified list of documents

---

## Solution Structure

```text
UnifiedDocumentViewer
│
├── UnifiedDocumentViewer (UI)
│   ├── Controllers
│   ├── Models
│   ├── Pages
│   ├── Services
│   ├── Views
│   ├── wwwroot
│   └── Program.cs
│
└── UnifiedDocumentViewerAPI (API)
    ├── Controllers
    ├── Models
    ├── Services
    ├── MockData
    │   ├── sales-documents.json
    │   └── service-documents.json
    └── Program.cs
```

---

## Architecture

```text
+-------------------------+
|  UnifiedDocumentViewer  |
|        (UI)             |
+------------+------------+
             |
             | HTTP Call
             |
             v
+-------------------------+
| UnifiedDocumentViewerAPI|
|       REST API          |
+------------+------------+
             |
      +------+------+
      |             |
      v             v
 Sales JSON    Service JSON
```

---

## Features

- Search documents by VIN
- RESTful API architecture
- Separation of UI and Backend layers
- Aggregation of documents from multiple sources
- Mock external systems using JSON files
- Asynchronous processing
- Dependency Injection
- Exception handling
- Configuration-driven API URL

---

## Technology Stack

### Frontend

- ASP.NET Core MVC / Razor Pages
- Bootstrap

### Backend

- ASP.NET Core Web API
- Swagger/OpenAPI
- Dependency Injection

### Data Source

- JSON files

---

## Prerequisites

Install:

- Visual Studio 2022
- .NET 8 SDK

Verify installation:

```bash
dotnet --version
```

Expected:

```text
8.x.x
```

---

## Configuration

### UI Application

File:

```text
UnifiedDocumentViewer/appsettings.json
```

Example:

```json
{
  "ApiSettings": {
    "BaseUrl": "https://localhost:44345/"
  }
}
```

Update the URL if the API runs on a different port.

---

## Mock Data Configuration

JSON files are located in:

```text
UnifiedDocumentViewerAPI/MockData
```

Files:

```text
sales-documents.json
service-documents.json
```

Sample:

```json
[
  {
    "id": "S1",
    "vin": "ABC123",
    "documentName": "Vehicle Invoice.pdf",
    "sourceSystem": "Sales System"
  }
]
```

---

## Building the Solution

Open the solution in Visual Studio.

Restore packages:

```bash
dotnet restore
```

Build solution:

```bash
dotnet build
```

Successful output:

```text
Build succeeded.
```

---

## Running the Applications

### Option 1 - Visual Studio

#### Configure Multiple Startup Projects

Right-click:

```text
Solution -> Properties
```

Select:

```text
Startup Project
```

Choose:

```text
Multiple startup projects
```

Set both projects to:

```text
Start
```

| Project | Action |
|----------|----------|
| UnifiedDocumentViewer | Start |
| UnifiedDocumentViewerAPI | Start |

Click:

```text
Apply
```

Start debugging:

```text
F5
```

---

### Option 2 - Command Line

Open two terminals.

#### Terminal 1

```bash
cd UnifiedDocumentViewerAPI
dotnet run
```

#### Terminal 2

```bash
cd UnifiedDocumentViewer
dotnet run
```

---

## Swagger Documentation

Once the API starts:

```text
https://localhost:44345/swagger
```

You should see the OpenAPI documentation.

---

## API Endpoint

### Get Documents By VIN

```http
GET /api/documents/{vin}
```

Example:

```http
GET /api/documents/ABC123
```

Response:

```json
[
  {
    "id": "S1",
    "vin": "ABC123",
    "documentName": "Vehicle Invoice.pdf",
    "sourceSystem": "Sales System"
  },
  {
    "id": "SV1",
    "vin": "ABC123",
    "documentName": "Service Report.pdf",
    "sourceSystem": "Service System"
  }
]
```

---

## UI Usage

1. Launch both applications.
2. Open the UI application in the browser.
3. Enter a VIN value.
4. Click Search.
5. Documents from all source systems will be displayed in a consolidated view.

Sample VIN:

```text
ABC123
```

---

## Error Handling

The API provides:

### 400 Bad Request

```json
{
  "message": "VIN is required."
}
```

### 404 Not Found

```json
{
  "message": "No documents found."
}
```

### 500 Internal Server Error

```json
{
  "message": "Unexpected error occurred."
}
```

---

## Assumptions

- JSON files simulate external dealership systems.
- Data is read-only.
- No authentication is required.
- VIN search is exact match.
- The UI communicates exclusively through REST APIs.

---

## Future Enhancements

- SQL Server integration
- JWT Authentication
- Azure Deployment
- Docker Support
- Caching with Redis
- Logging with Serilog
- Unit Testing
- Pagination and Filtering
- Search enhancements

---

## Author

Unified Document Viewer

Built using ASP.NET Core MVC, Razor Pages, and ASP.NET Core Web API.