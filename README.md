### Requirements

See [SRS document](https://docs.google.com/document/d/1Luq4SzilKKOuf-xOaeI8qnIUYTr-38Tx_36KlQczMdc/edit?usp=sharing)

### Architecture tree
```
Panteleimon
│
├── Platform
│   ├── Identity & Access
│   ├── Administration
│   ├── Support
│   ├── Billing
│   └── Reporting
│
├── Business
│   ├── Area
│   ├── Owner
│   ├── Pharmacy
│   ├── Doctor
│   ├── Patient
│   ├── Prescription
│   └── Order
│
├── Operations
│   ├── Delivery Planning
│   ├── Fleet Management
│   ├── Flight Control
│   ├── Scheduling
│   └── Notifications
│
├── Interfaces
│   ├── REST API
│   ├── Blazor Web
│   └── SignalR
│
├── Infrastructure
│   ├── Persistence
│   ├── MAVLink
│   ├── Payment Providers
│   ├── Notification Providers
│   └── External Integrations
│
└── Cross-cutting
    ├── Logging
    ├── Observability
    ├── Performance Monitoring
    └── Security
```