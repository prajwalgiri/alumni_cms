# Task List: Integrated Member Management & Engagement Infrastructure (IMMEI)

This document outlines the high-level features and a granular, sprint-based roadmap for the IMMEI project using an Agile methodology.

## High-Level Major Features

1.  **Identity & Access Management (IAM):** Secure authentication and granular Role-Based Access Control (RBAC).
2.  **Member Profile & Portfolio System:** Comprehensive management of member information, including professional portfolios and public visibility controls.
3.  **Event Lifecycle Management:** Tools for creating, managing, and tracking attendance for both physical and virtual events.
4.  **Integrated Notices & News System:** Internal and public communication system for announcements and event notifications.
5.  **Dynamic Navigation & UX:** A customizable, role-aware interface for all user types.
6.  **Analytics & Reporting:** Data-driven insights into member engagement and event performance.
7.  **Financial & Subscription Management:** (Future) Automated handling of membership fees and subscriptions.

---

## Granular Task List & Sprint Plan (1-Week Sprints)

### Sprint 1: Content Management Backend & Public Notices
**Goal:** Implement the missing Content/Notices backend and enable public announcements.

*   **Task 1.1 (BE):** Create `Content` entity in Domain layer (Title, Body, Type, Status, PublishDate).
*   **Task 1.2 (BE):** Implement MediatR Commands/Queries for Content (CRUD & Publish).
*   **Task 1.3 (BE):** Create `ContentController` and expose REST endpoints.
*   **Task 1.4 (BE):** Update `SeedData` to include initial notices/news items.
*   **Task 1.5 (FE):** Update `apiService` to include Content Management methods.
*   **Task 1.6 (FE):** Create a Public Notices/News page for unauthenticated users.
*   **Task 1.7 (FE):** Integrate News/Announcements into the Admin Content Management dashboard.

### Sprint 2: Member Portfolio & Gallery Expansion
**Goal:** Enhance Alumni profiles to support "Thoughts and Work" and improve the gallery view.

*   **Task 2.1 (BE):** Extend `Alumni` entity with `PortfolioItems` (SQLite JSON column or separate table) and `ProfessionalThoughts`.
*   **Task 2.2 (BE):** Update DTOs and MediatR handlers for Alumni profile updates.
*   **Task 2.3 (FE):** Redesign the Alumni Profile edit page to include Portfolio/Thoughts sections.
*   **Task 2.4 (FE):** Update the Public Alumni Gallery (`/alumni`) to display a preview of portfolio highlights.
*   **Task 2.5 (FE):** Implement a dedicated "Member Portfolio" detail page with a "Portfolio of the Member" layout.
*   **Task 2.6 (FE):** Add image upload support for portfolio items (using a mock or simple URL storage for now).

### Sprint 3: Advanced Notices & Internal Notifications
**Goal:** Implement the internal notification system for event invitations and announcements.

*   **Task 3.1 (BE):** Create a `Notification` system for internal alerts (User-specific).
*   **Task 3.2 (BE):** Implement a trigger to automatically notify members when a new event is created.
*   **Task 3.3 (FE):** Add a notification "bell" icon and dropdown in the main layout.
*   **Task 3.4 (FE):** Create a dedicated Notifications center in the User Dashboard.
*   **Task 3.5 (FE):** Implement "Read/Unread" status for notifications.

### Sprint 4: Analytics, Quality & Testing
**Goal:** Improve system reliability and provide initial insights through the Analytics dashboard.

*   **Task 4.1 (BE):** Implement Unit Tests for core business logic (MediatR Handlers).
*   **Task 4.2 (BE):** Add Integration Tests for API endpoints using WebApplicationFactory.
*   **Task 4.3 (BE):** Create summary queries for Analytics (Growth trends, Event attendance rates).
*   **Task 4.4 (FE):** Complete the Analytics Dashboard in the CMS (`/admin/analytics`) with interactive charts (using Chart.js or similar).
*   **Task 4.5 (FE):** Conduct a full UX audit and fix responsive design issues in the CMS tables.

### Sprint 5: Subscription Management & Payment Foundation
**Goal:** Start implementing the infrastructure for managing organization subscriptions.

*   **Task 5.1 (BE):** Design `SubscriptionTier` and `UserSubscription` entities.
*   **Task 5.2 (BE):** Implement logic for tracking subscription expiry and status (Active, Overdue).
*   **Task 5.3 (BE):** Integrate a mock Payment Gateway service (e.g., Stripe/PayPal integration prep).
*   **Task 5.4 (FE):** Create a "Subscription & Billing" page in the User Settings.
*   **Task 5.5 (FE):** Add subscription status indicators to the Admin User Management table.

---

## Task Categorization

### 🔴 Critical / High Priority
- Sprint 1 & 2 tasks (Core functionality gaps).
- Security audits and JWT token expiration handling.

### 🟡 Medium Priority
- Sprint 3 (Notifications) and Sprint 4 (Analytics).
- Enhancing Search & Filter capabilities with better performance.

### 🟢 Low Priority / Backlog
- Sprint 5 (Subscriptions).
- Advanced export capabilities (PDF/Excel) for reports.
- Multi-language (i18n) support.
