# BoxContains

This project is tracking the contains of storage boxes to easily identify where you stored items.

## Folder Structure
This project follows the following folder structure:
```
- docs: Contains documentation about the project
	- requirements: Contains the project requirements by version.  Inside the version folder, you will find the scope, business requirement, functional requirement, and any other associated figures (source and image).
- src: Contains the source code of the project
	- BoxContains.Category: All the projects associated with the Category (See Notes #1)
		- src
			- core: Contains Application and Domain Layers of the Project
				- BoxContains.Category.Application
				- BoxContains.Category.Domain
			- infrastructure: Contains the Infrastructure Layers of the Project
				- BoxContains.Category.Persistence
			- interfaces: Contains the Interface Layers of the Project
		- tests: Contains the test plans for the project
- tests: Contains the test plans for the project

Root Folder contains the README, License, Solution File, and any other files required to be there.
```
## Notes
1. I don't normally embed projects this but I wanted the entire in a single Git Repository so src has this additional layer
