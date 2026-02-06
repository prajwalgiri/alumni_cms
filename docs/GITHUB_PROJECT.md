# GitHub Project: Integrated Member Management & Engagement Infrastructure (IMMEI)

## Project Description
The **Integrated Member Management & Engagement Infrastructure (IMMEI)** is a robust, enterprise-grade system designed to store and manage the information of an organization, leveraging that data to actively engage with its members.

> **Vision:** "This system stores the information of an organization to engage with its members and manage all aspects of their membership—from personal and professional information to subscriptions, event invitations, and organizational notices."

## Goals
- **Centralized Data:** Provide a single source of truth for all member-related data.
- **Engagement Excellence:** Facilitate meaningful interactions through managed events and automated notices.
- **Member Portfolios:** Empower members to showcase their achievements, thoughts, and professional work through a public-facing gallery.
- **Role-Based Efficiency:** Streamline administrative tasks with a powerful CMS and granular access controls.
- **Scalable Infrastructure:** Maintain a clean, modular architecture that supports future growth and integrations.

---

## Information for Stakeholders & Users
IMMEI is designed to be the backbone of your organization's digital presence.
- **For Users (Members):** Access a personalized dashboard, connect with fellow members, manage your professional portfolio, and stay updated on the latest events and news.
- **For Organization Leaders:** Gain insights through analytics, manage the member base efficiently, and broadcast important information seamlessly.

---

## Information for Potential Contributors

We welcome contributions from the community! To maintain a high standard of quality, please follow the guidelines below.

### Tech Stack
- **Frontend:** SvelteKit (TypeScript), Tailwind CSS.
- **Backend:** .NET 8 (C#), Entity Framework Core, MediatR.
- **Database:** PostgreSQL.

### Coding Standards
- **Clean Architecture:** Adhere to the established layers: Domain, Application, Infrastructure, and WebAPI.
- **CQRS Pattern:** Use MediatR for all business logic operations (Commands for state changes, Queries for data retrieval).
- **Type Safety:** Ensure all frontend code is strictly typed using TypeScript.
- **Styling:** Use Tailwind CSS utility classes. Avoid custom CSS unless absolutely necessary.
- **Naming Conventions:**
    - **Backend:** PascalCase for classes and methods, camelCase for local variables.
    - **Frontend:** camelCase for functions and variables, PascalCase for components.
- **Testing:** New features should include relevant unit tests in the Application layer.

### Pull Request (PR) Process
1.  **Issue First:** Before starting work, ensure there is an open issue for the task.
2.  **Branching:** Create a descriptive branch name (e.g., `feature/member-portfolio` or `bugfix/auth-leak`).
3.  **Local Testing:** Verify your changes locally by running both the frontend and backend.
4.  **Commits:** Use clear, descriptive commit messages.
5.  **Documentation:** Update relevant markdown files in the `docs/` folder if your change affects the project's structure or workflow.
6.  **Review:** All PRs must be reviewed and approved by at least one maintainer before merging.

---

## Project Structure (Quick Reference)
- `be/`: .NET 8 Backend Solution.
- `fe/`: SvelteKit Frontend Application.
- `docs/`: Project documentation and task lists.
- `docker-compose.yml`: Full environment orchestration.
