﻿[![NuGet Downloads][nuget-shield]][nuget-url][![Contributors][contributors-shield]][contributors-url][![Forks][forks-shield]][forks-url][![Stargazers][stars-shield]][stars-url][![Issues][issues-shield]][issues-url][![License][license-shield]][license-url][![LinkedIn][linkedin-shield]][linkedin-url]

# ![Logo][Logo] TirsvadWeb Portfolio Domain library

TirsvadWeb.Portfolio.Domain is a .NET class library that provides a robust, extensible domain model for portfolio and resume management systems.
It defines core entities such as Person, Project, Education, Skill, and WorkExperience, supporting strong typing, validation, and clean architecture principles.
The library is suitable for use in web applications, APIs, or any .NET-based solution requiring structured portfolio data.

## Table of Contents

- [Getting Started](#getting-started)
  - [Prerequisites](#prerequisites)
  - [Installation](#installation)
    - [NuGet Package](#nuget-package)
    - [Clone the repo](#clone-the-repo)
- [Folder Structure](#folder-structure)
- [Contributing](#contributing)
- [Bug / Issue Reporting](#bug--issue-reporting)
- [License](#license)
- [Contact](#contact)
- [Acknowledgments](#acknowledgments)

## Getting Started

### Prerequisites
- Dotnet 9.0 or later

### Installation
The TirsvadWeb.Portfolio.Domain library can be installed in several ways:

#### NuGet Package
```
dotnet add package TirsvadWeb.Portfolio.Domain
```
Then, run your package manager's install command to download and install the module.

#### Clone the repo
![Repo size][repos-size-shield]

```bash
git clone git@github.com:TirsvadWeb/Dotnet.Portfolio.Domain.git
```

## 📂 Folder Structure
```
TirsvadWeb.Portfolio.Domain/
├── 📄 docs                                // Documentation files
│   └── 📄 doxygen                         // Doxygen output
├── 🖼️ images                              // Images used in documentation
├── 📂 src                                 // Source code for the library
│   └── 📦 TirsvadWeb.Portfolio.Domain     // Main library folder
│       ├── 📦 Entities                    // Contains domain entities
│       ├── 📦 Exceptions                  // Custom exceptions for the domain
│       ├── 📦 Interfaces                  // Interfaces for domain services
│       ├── 📦 Services                    // Domain services
│       └── 📦 ValueObjects                // Value objects for the domain
└── 📂 tests
    └── 🧪 TestDomain                      // Unit tests for the library
        ├── 🧪 Entities                    // Contains tests for domain entities
        ├── 🧪 Exceptions                  // Tests for custom exceptions
        ├── 🧪 Interfaces                  // Tests for domain interfaces
        └── 🧪 Services                    // Tests for domain services
```

## Contributing
Contributions are what make the open-source community such an amazing place to learn, inspire, and create. Any contributions you make are **greatly appreciated**.

See [CONTRIBUTING.md](CONTRIBUTING.md)

## Bug / Issue Reporting  
If you encounter a bug or have an issue to report, please follow these steps:  

1. **Go to the Issues Page**  
  Navigate to the [GitHub Issues page][githubIssue-url].  

2. **Click "New Issue"**  
  Click the green **"New Issue"** button to create a new issue.  

3. **Provide Details**  
  - **Title**: Write a concise and descriptive title for the issue.  
  - **Description**: Include the following details:  
    - Steps to reproduce the issue.  
    - Expected behavior.  
    - Actual behavior.  
    - Environment details (e.g., OS, .NET version, etc.).  
  - **Attachments**: Add screenshots, logs, or any other relevant files if applicable.  

4. **Submit the Issue**  
  Once all details are filled in, click **"Submit new issue"** to report it.  

## License
Distributed under the AGPL-3.0 [License][license-url].

## Contact
Jens Tirsvad Nielsen - [LinkedIn][linkedin-url]

## Acknowledgments
<!-- MARKDOWN LINKS & IMAGES -->
[contributors-shield]: https://img.shields.io/github/contributors/TirsvadWeb/Dotnet.Portfolio.Domain?style=for-the-badge
[contributors-url]: https://github.com/TirsvadWeb/Dotnet.Portfolio.Domain/graphs/contributors
[forks-shield]: https://img.shields.io/github/forks/TirsvadWeb/Dotnet.Portfolio.Domain?style=for-the-badge
[forks-url]: https://github.com/TirsvadWeb/Dotnet.Portfolio.Domain/network/members
[stars-shield]: https://img.shields.io/github/stars/TirsvadWeb/Dotnet.Portfolio.Domain?style=for-the-badge
[stars-url]: https://github.com/TirsvadWeb/Dotnet.Portfolio.Domain/stargazers
[issues-shield]: https://img.shields.io/github/issues/TirsvadWeb/Dotnet.Portfolio.Domain?style=for-the-badge
[issues-url]: https://github.com/TirsvadWeb/Dotnet.Portfolio.Domain/issues
[license-shield]: https://img.shields.io/github/license/TirsvadWeb/Dotnet.Portfolio.Domain?style=for-the-badge
[license-url]: https://github.com/TirsvadWeb/Dotnet.Portfolio.Domain/blob/master/LICENSE.txt
[linkedin-shield]: https://img.shields.io/badge/-LinkedIn-black.svg?style=for-the-badge&logo=linkedin&colorB=555
[linkedin-url]: https://www.linkedin.com/in/jens-tirsvad-nielsen-13b795b9/
[githubIssue-url]: https://github.com/TirsvadWeb/Dotnet.Portfolio.Domain/issues/
[repos-size-shield]: https://img.shields.io/github/repo-size/TirsvadWeb/Dotnet.Portfolio.Domain?style=for-the-badg

[logo]: https://raw.githubusercontent.com/TirsvadWeb/Dotnet.Portfolio.Domain/master/images/logo/32x32/logo.png

<!-- If this is a Nuget package -->
[nuget-shield]: https://img.shields.io/nuget/dt/TirsvadWeb.Portfolio.Domain?style=for-the-badge
[nuget-url]: https://www.nuget.org/packages/TirsvadWeb.Portfolio.Domain/
