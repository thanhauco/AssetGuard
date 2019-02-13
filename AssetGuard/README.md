# AssetGuard

AssetGuard is a comprehensive corporate asset tracking and management application built with **.NET Core 2.1**, adhering to enterprise architectural patterns.

## System Architecture

```mermaid
graph TB
    subgraph "Presentation Layer"
        API[AssetGuard.Api<br/>REST Controllers]
    end
    
    subgraph "Business Layer"
        Services[AssetGuard.Services<br/>Domain Services]
        Depreciation[Depreciation Engine]
        Notifications[Notification System]
    end
    
    subgraph "Data Layer"
        Data[AssetGuard.Data<br/>EF Core Context]
        UoW[Unit of Work]
        Specs[Specification Evaluator]
    end
    
    subgraph "Domain Layer"
        Core[AssetGuard.Core<br/>Entities & Interfaces]
    end
    
    API --> Services
    Services --> Depreciation
    Services --> Notifications
    Services --> Data
    Data --> UoW
    Data --> Specs
    Data --> Core
    
    style API fill:#e1bee7,stroke:#7b1fa2,stroke-width:2px
    style Services fill:#bbdefb,stroke:#1976d2,stroke-width:2px
    style Data fill:#c8e6c9,stroke:#388e3c,stroke-width:2px
    style Core fill:#ffecb3,stroke:#f57c00,stroke-width:2px
```

## Module Overview

```mermaid
block-beta
    columns 3
    
    block:core["Core Modules"]:3
        Assets["Asset<br/>Management"]
        Employees["Employee<br/>Directory"]
        Locations["Location<br/>Hierarchy"]
    end
    
    block:ops["Operations"]:3
        Maintenance["Maintenance<br/>& Repairs"]
        Issues["Issue<br/>Tracking"]
        Transfers["Transfer<br/>History"]
    end
    
    block:finance["Finance & Compliance"]:3
        Procurement["Procurement<br/>& POs"]
        Insurance["Insurance<br/>& Warranty"]
        Depreciation2["Depreciation<br/>Calculator"]
    end
    
    block:enterprise["Enterprise Features"]:3
        Reporting["Reporting<br/>& Dashboards"]
        Workflows["Workflow<br/>& Approvals"]
        Documents["Document<br/>Management"]
    end
```

## Entity Relationships

```mermaid
erDiagram
    Asset ||--o{ MaintenanceRecord : "has"
    Asset ||--o{ Assignment : "assigned via"
    Asset }o--|| Category : "belongs to"
    Asset ||--o{ AssetTransfer : "tracks history"
    Asset ||--o{ AssetReservation : "can be reserved"
    Asset ||--o{ Warranty : "covered by"
    Asset ||--o{ InsurancePolicy : "insured by"
    
    Employee ||--o{ Assignment : "receives"
    Employee ||--o{ AssetReservation : "requests"
    Employee ||--o{ AssetTransfer : "initiates"
    
    Vendor ||--o{ Contract : "manages"
    Vendor ||--o{ PurchaseOrder : "fulfills"
    
    PurchaseRequest ||--o{ Quote : "receives"
    PurchaseRequest ||--|| PurchaseOrder : "becomes"
    
    AuditSession ||--o{ AuditScan : "contains"
    AuditSession ||--o{ DiscrepancyReport : "generates"
    
    Asset {
        int Id
        string Name
        string SerialNumber
        decimal PurchasePrice
        AssetStatus Status
    }
    
    Employee {
        int Id
        string FirstName
        string LastName
        string Department
    }
```

## Request Flow

```mermaid
sequenceDiagram
    participant Client
    participant Controller
    participant Service
    participant Repository
    participant Database
    
    Client->>Controller: HTTP Request
    Controller->>Service: Business Operation
    Service->>Repository: Data Query
    Repository->>Database: SQL via EF Core
    Database-->>Repository: Results
    Repository-->>Service: Entities
    Service-->>Controller: DTO Response
    Controller-->>Client: HTTP Response
```

## Procurement Workflow

```mermaid
stateDiagram-v2
    [*] --> Draft: Create Request
    Draft --> Submitted: Submit
    Submitted --> Approved: Manager Approves
    Submitted --> Rejected: Manager Rejects
    Approved --> Ordered: PO Created
    Ordered --> Received: Assets Delivered
    Received --> [*]: Complete
    Rejected --> [*]
```

## Key Modules

| Module | Description | Key Entities |
|--------|-------------|--------------|
| **Assets** | Core tracking, categorization, assignments | Asset, Category, Assignment |
| **Maintenance** | Repairs, vendor management | MaintenanceRecord, Vendor, Contract |
| **Issues** | Ticketing, job scheduling | Issue, Job |
| **Procurement** | Purchase requests, POs, quotes | PurchaseRequest, Quote, PurchaseOrder |
| **Audit** | Physical inventory verification | AuditSession, AuditScan, DiscrepancyReport |
| **Insurance** | Warranty & policy tracking | Warranty, InsurancePolicy |
| **Reservations** | Asset booking system | AssetReservation |
| **Transfers** | Location/ownership changes | AssetTransfer |
| **Reporting** | Dashboards, scheduled reports | ReportDefinition, DashboardWidget |
| **Notifications** | Alerts, subscriptions | Notification, NotificationTemplate |
| **Documents** | Version-controlled files | Document, DocumentVersion |
| **Workflows** | Approval processes | Workflow, ApprovalRequest |

## Getting Started

1. Ensure .NET Core 2.1 SDK is installed.
2. Run `dotnet restore`.
3. Run `dotnet run` from the `AssetGuard.Api` directory.

## Project Statistics

- **Files**: 280+ C# source files
- **Modules**: 15+ feature modules
- **Unit Tests**: Comprehensive coverage with xUnit + Moq
- **Timeline**: 2018-2019 development cycle
