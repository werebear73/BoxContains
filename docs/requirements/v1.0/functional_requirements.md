# Functional Requirements
## Functional Process Requirements
### Workflows
### System Use Cases
---
#### Add Category
**Use Case ID:** UC1

**Created By:** Sam D Ware

**Date Created:** 8/23/2024**

**Actors:** User

**Description:** This is for the user to create a new Category that can be assigned to Items

**Pre-conditions:** User has a name for the Category

**Post-conditions:** The new category is stored persistently.

**Priority:** M

**Frequency of Use:** 1-2 times per month and initial setup of system

**Primary Path:**

|Actor Actions|System Actions|
|:---:|:---:|
|User Submits the request||
||System validates Request values met validation rules|
||System saves a record of the new Category persistently and in-memory|
||System responds to the user that the new Category has been created|


**Alternate Path #1:**

|Actor Actions|System Actions|
|:---:|:---:|
|User Submits the request||
||System validates Request values does NOT met validation rules|
||System responds to the User with the Rules that have been violated|

**Alternate Path #2:**

|Actor Actions|System Actions|
|:---:|:---:|
|User Submits the request||
||System validates Request values met validation rules|
||System tries to save a record of the new Category persistently and in-memory and an error occurs|
||System responds to the user that an error has occuring and to please try again.|

---
#### Get Category
**Use Case ID:** UC2

**Created By:** Sam D Ware

**Date Created:** 8/23/2024**

**Actors:** User

**Description:** This is for the user to retrieve details about a Category

**Pre-conditions:** User knows the Category.

**Post-conditions:** The category is presented with the details of the Category.

**Priority:** M

**Frequency of Use:** On the presentation of an item details. 

**Primary Path:**

|Actor Actions|System Actions|
|:---:|:---:|
|User Submits the request||
||System searchs for the Category|
||System find the Category|
||System responds to the user that the Category details|


**Alternate Path #1:**

|Actor Actions|System Actions|
|:---:|:---:|
|User Submits the request||
||System searchs for the Category|
||System can NOT find the Category|
||System responds to the user that the Category was not found|

---
#### Get a List of all Categories
**Use Case ID:** UC3

**Created By:** Sam D Ware

**Date Created:** 8/23/2024**

**Actors:** User

**Description:** This is for the user to retrieve a list of all Categories

**Pre-conditions:** User wants a list of all Categories.

**Post-conditions:** The list of categories is presented to the user.

**Priority:** M

**Frequency of Use:** On creation of an item details. 

**Primary Path:**

|Actor Actions|System Actions|
|:---:|:---:|
|User Submits the request||
||System pulls a list of all Categories|
||System responds to the user with the list of Categories


**Alternate Path #1:**

|Actor Actions|System Actions|
|:---:|:---:|
|User Submits the request||
||System pulls a list of all Categories|
||System encounts an error|
||System responds to the user that the request failed|

---
#### System Use Case Name
**Use Case ID:**

**Created By:**
**Date Created:**

**Actors:**

**Description:**

**Pre-conditions:**
**Post-conditions:**

**Priority:**

**Frequency of Use:**

**Primary Path:**

|Actor Actions|System Actions|
|:---:|:---:|
|Actor Does Something||
||System Does Something|

**Alternate Path #1:**

|Actor Actions|System Actions|
|:---:|:---:|
|Actor Does Something||
||System Does Something|

**Alternate Path #2:**

|Actor Actions|System Actions|
|:---:|:---:|
|Actor Does Something||
||System Does Something|

---
## Functional Data Requirements
### ERD
[See Business Requirement's ERD](business_requirements.md#entity-relationship-diagram) as no changes for been determined for the functional requirements.
### Attribute Details
[See Business Requirement's Entity Details](business_requirements.md#entity-details) as no changes for been determined for the functional requirements.

### Data Mappinig
|Physical<hr>Table|Physical<hr>Column|Business<hr>Entity|Business<hr>Attribute|
|:---:|:---:|:---:|:---:|
|||||

### Data Transformation
None

***---Detailed Data Transformation Template---***

#### Data Transformation Header

||Source|Target|
|:---|:---:|:---:|
|Element Name|||
|Data type|||
|Data length|||
|Location (database/file)|||
|Owner|||
|Conversion rules|||
|Frequency of update|||
|Triggering event for update|||

**Other Transformation Rules:**

***---END of Detailed Data Transformation Template---***

## Functional Interface Requirements
### Screen prototypes
#### Screen Name
**Screen ID:**

**Screen Purpose/Description:**

***Insert Wireframe Here***

|Screen Field|Attribute and Edit Requirements|
|:---:|:---:|
|||

|Screen Function|Description|
|:---:|:---:|
|||
