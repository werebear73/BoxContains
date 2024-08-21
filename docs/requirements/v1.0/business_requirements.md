# Business Requirements
## Business Process Requirements
### Process Decomposition Diagram
![Process Decomposition Diagram](process_decomposition_diagram.svg)
### Process List
1. Track Storage Containers
   1. [Add a Storage Container](####add-a-storage-container)
   1. [Edit a Storage Container](####edit-a-storage-container)
   1. [List Storage Containers](####list-storage-containers)
   1. [Get Storage Container Details](####get-storage-container-details)
   1. [Delete a Storage Container](####delete-a-storage-container)
1. Track Categories
   1. [Add a Category](####add-a-category)
   1. [Edit a Category](####edit-a-category)
   1. [List Categories](####list-categories)
   1. [Get Category Details](####get-category-details)
   1. [Delete a Category](####delete-a-category)
1. Track Items
   1. [Add an Item](####add-an-item)
   1. [Edit an Item](####edit-an-item)
   1. [List All Items](####list-all-items)
   1. [Get Item Details](####get-item-details)
   1. [Delete a Item](####delete-a-item)

### Process Details
___
#### Add a Storage Container
**Process ID:** BP1i

**Detailed Description:** Add a new Storage Container record.  

**External Agents Involved:** User

**What causes the process to occur?:** The user requests to create a new record

**What happens after the process is complete?:** The record is stored persistently.

**Business rules:** 

| Data Attributes | CRUD | Source
|:---|:---:|:---|
|storage container id|C|Unique Identifier of the Storage Container|
|storage container name|C|Name of the Storage Container|
|storage container label|C|Label on the Storage Container|

**Additional notes:** 

**Information source:** 
___
#### Edit a Storage Container
**Process ID:** BP1ii

**Detailed Description:** Changed the values of the details of the Storage Container.

**External Agents Involved:** User

**What causes the process to occur?:** The user requests to change the record data.

**What happens after the process is complete?:** The Storage Container's data is changed in persistent storage.

**Business rules:** The unique identifier can NOT be changed.

| Data Attributes | CRUD | Source
|:---|:---:|:---|
|storage container id|R|Unique Identifier of the Storage Container|
|storage container name|U|Name of the Storage Container|
|storage container label|U|Label on the Storage Container|

**Additional notes:** 

**Information source:** 
___
#### List Storage Containers
**Process ID:** BP1iii

**Detailed Description:** This returns a list of all Storage Containers

**External Agents Involved:** User

**What causes the process to occur?:** The user requests to get the record data.

**What happens after the process is complete?:** Data is presented.

**Business rules:** 

| Data Attributes | CRUD | Source
|:---|:---:|:---|
|storage container id|R|Unique Identifier of the Storage Container|
|storage container name|R|Name of the Storage Container|
|storage container label|R|Label on the Storage Container|

**Additional notes:** 

**Information source:** 
___
#### Get Storage Container Details
**Process ID:** BP1iv

**Detailed Description:** Retrieve the details of a Storage Container from persistent storage

**External Agents Involved:** User

**What causes the process to occur?:** The user requests to get the record data.

**What happens after the process is complete?:** Data is presented.

**Business rules:** 

| Data Attributes | CRUD | Source
|:---|:---:|:---|
|storage container id|R|Unique Identifier of the Storage Container|
|storage container name|R|Name of the Storage Container|
|storage container label|R|Label on the Storage Container|

**Additional notes:** 

**Information source:** 
___
#### Delete a Storage Container
**Process ID:** BP1v

**Detailed Description:** Remove the Storage Container record.  Update any items in the Storage Container and make them no longer in a container.

**External Agents Involved:** User

**What causes the process to occur?:** The user requests to delete the record.

**What happens after the process is complete?:** The record is delete for local and persistent storage.  Update all items with this storage_container_id to NULL for that value.

**Business rules:** 

| Data Attributes | CRUD | Source
|:---|:---:|:---|
|storage container id|D|Unique Identifier of the Storage Container|
|storage container name|D|Name of the Storage Container|
|storage container label|D|Label on the Storage Container|

**Additional notes:** Reminder that there needs to be update to the Items that are in the Storage Container that is being deleted.

**Information source:** 
___
#### Add a Category
**Process ID:** BP2i

**Detailed Description:** Add a new Category record.  

**External Agents Involved:** User

**What causes the process to occur?:** The user requests to create a new record

**What happens after the process is complete?:** The record is stored persistently.

**Business rules:** 

| Data Attributes | CRUD | Source
|:---|:---:|:---|
|category id|C|Unique Identifier of the Category|
|category name|C|Name of the Category|

**Additional notes:** 

**Information source:** 
___
#### Edit a Category
**Process ID:** BP2ii

**Detailed Description:** 

**External Agents Involved:** User

**What causes the process to occur?:** The user requests to change the record data.

**What happens after the process is complete?:** The Category's data is changed in persistent storage.

**Business rules:** 

| Data Attributes | CRUD | Source
|:---|:---:|:---|
|category id|R|Unique Identifier of the Category|
|category name|U|Name of the Category|

**Additional notes:** 

**Information source:** 
___
#### List Categories
**Process ID:** BP2iii

**Detailed Description:** This returns a list of all Categories

**External Agents Involved:** User

**What causes the process to occur?:** The user requests to get the record data.

**What happens after the process is complete?:** Data is presented.

**Business rules:** 

| Data Attributes | CRUD | Source
|:---|:---:|:---|
|category id|R|Unique Identifier of the Category|
|category name|R|Name of the Category|

**Additional notes:** 

**Information source:** 
___
#### Get Category Details
**Process ID:** BP2iv

**Detailed Description:** 

**External Agents Involved:** User

**What causes the process to occur?:** The user requests to get the record data.

**What happens after the process is complete?:** Data is presented.

**Business rules:** 

| Data Attributes | CRUD | Source
|:---|:---:|:---|
|category id|R|Unique Identifier of the Category|
|category name|R|Name of the Category|

**Additional notes:** 

**Information source:** 
___
#### Delete a Category
**Process ID:** BP2v

**Detailed Description:** Remove the Category record.  This request requires that the user designate a new category that all items in the category, being deleted, are updated with the new category.

**External Agents Involved:** User

**What causes the process to occur?:** The user requests to delete the record.

**What happens after the process is complete?:** The record is delete for local and persistent storage.

**Business rules:** 

| Data Attributes | CRUD | Source
|:---|:---:|:---|
|category id|D|Unique Identifier of the Category|
|category name|D|Name of the Category|

**Additional notes:** 

**Information source:** 
___
#### Add an Item
**Process ID:** BP3i

**Detailed Description:** Add a new Item record.  

**External Agents Involved:** User

**What causes the process to occur?:** The user requests to create a new record

**What happens after the process is complete?:** The record is stored persistently.

**Business rules:** 

| Data Attributes | CRUD | Source
|:---|:---:|:---|
|item id|C|Unique Identifier of the Item|
|quantity|C|Number of Items|
|storage container id|C|Unique Identifier of the Storage Container that the item(s) are in|
|cateogry id|C|Unique Identifier of the Category that the item is.|
|in use|C|If the item is currently in use and out of the Storage Container|

**Additional notes:** 

**Information source:** 
___
#### Edit an Item
**Process ID:** BP3ii

**Detailed Description:** 

**External Agents Involved:** User

**What causes the process to occur?:** The user requests to change the record data.

**What happens after the process is complete?:** The Items's data is changed in persistent storage.

**Business rules:** 

| Data Attributes | CRUD | Source
|:---|:---:|:---|
|item id|R|Unique Identifier of the Item|
|quantity|U|Number of Items|
|storage container id|U|Unique Identifier of the Storage Container that the item(s) are in|
|cateogry id|U|Unique Identifier of the Category that the item is.|
|in use|U|If the item is currently in use and out of the Storage Container|

**Additional notes:** 

**Information source:** 
___

#### List All Items
**Process ID:** BP3ii

**Detailed Description:** This returns a list of all Items

**External Agents Involved:** User

**What causes the process to occur?:** The user requests to get the record data.

**What happens after the process is complete?:** Data is presented.

**Business rules:** 

| Data Attributes | CRUD | Source
|:---|:---:|:---|
|item id|R|Unique Identifier of the Item|
|quantity|R|Number of Items|
|storage container id|R|Unique Identifier of the Storage Container that the item(s) are in|
|cateogry id|R|Unique Identifier of the Category that the item is.|
|in use|R|If the item is currently in use and out of the Storage Container|

**Additional notes:** 

**Information source:** 
___

#### Get Item Details
**Process ID:** BP3iv

**Detailed Description:** 

**External Agents Involved:** User

**What causes the process to occur?:** The user requests to get the record data.

**What happens after the process is complete?:** Data is presented.

**Business rules:** 

| Data Attributes | CRUD | Source
|:---|:---:|:---|
|item id|R|Unique Identifier of the Item|
|quantity|R|Number of Items|
|storage container id|R|Unique Identifier of the Storage Container that the item(s) are in|
|cateogry id|R|Unique Identifier of the Category that the item is.|
|in use|R|If the item is currently in use and out of the Storage Container|

**Additional notes:** 

**Information source:** 
___
#### Delete a Item
**Process ID:** BP3v

**Detailed Description:** Remove the Item record.

**External Agents Involved:** User

**What causes the process to occur?:** The user requests to delete the record.

**What happens after the process is complete?:** The record is delete for local and persistent storage.

**Business rules:** 

| Data Attributes | CRUD | Source
|:---|:---:|:---|
|item id|D|Unique Identifier of the Item|
|quantity|D|Number of Items|
|storage container id|D|Unique Identifier of the Storage Container that the item(s) are in|
|cateogry id|D|Unique Identifier of the Category that the item is.|
|in use|D|If the item is currently in use and out of the Storage Container|

**Additional notes:** 

**Information source:** 
___

***---COPY THIS TEMPLATE TO ADD ADDITIONAL PROCESS DETAILS---***
#### Process Detail Template
**Process ID:** BP####

**Detailed Description:** 

**External Agents Involved:** 

**What causes the process to occur?:** 

**What happens after the process is complete?:** 

**Business rules:** 

| Data Attributes | CRUD | Source
|:---|:---:|:---|
||||

**Additional notes:** 

**Information source:** 

***---END OF PROCESS DETAILS TEMPLATE---***
___


## Business Data Requirements
### Entities

| ID | Entity Name | Unique Identifier | Number of Occurances | Owner |
|:---:|:---|:---|:---:|:---|
|EN1|Storage Container|Storage Container ID|50|User|
|EN2|Category|Category ID|10|User|
|EN3|Item|Item ID|500|User


### Entity Relationship Diagram
![Entity Relationship Diagram](entity_relationship_diagram.svg)
### Entity Details

#### Storage Container
| Name | U | M | R | Data Type / Length | Valid Values | Default Values | Owner | Definition |
|:---|:---:|:---:|:---:|:---|:---:|:---:|:---:|:---|
|storage_container_id|Y|Y|N|int|positive|auto-increment|database|Storage Container Unique Identifier|
|storage_container_name|Y|N|N|string|Any|NULL|user|Name of the Storage Container|
|storage_container_label|Y|Y|N|string|Any|N/A|user|Label on the Storage Container|

##### Attribute Validation and Defaults
|Attribute Name|Validation|Default|Comments|
|:---:|:---:|:---:|:---|
|storage_container_id||Auto-Incremented by Database||
|storage_container_name|Length less 255 characters|NULL||
|storage_container_label|Length less 255 characters||

##### Relationships
|Entity Pair|Foreign Key|Business Rule|Type|Comments
|:---:|:---:|:---:|:---:|:---:|
|Storage Container<br>&<br>Item|FK1||One-to-Many<br>Storage Container / Item|This relationship represents that the items are in the Storage Container|

#### Category
| Name | U | M | R | Data Type / Length | Valid Values | Default Values | Owner | Definition |
|:---|:---:|:---:|:---:|:---|:---:|:---:|:---:|:---|
|category_id|Y|Y|N|int|positive|auto-increment|database|Category Unique Identifier|
|category_name|Y|Y|N|string|Not zero length string|N/A|user|Name for the Category|

##### Attribute Validation and Defaults
|Attribute Name|Validation|Default|Comments|
|:---:|:---:|:---:|:---|
|category_id||Auto-Incremented by Database||
|category_name|Length less 255 characters|N/A||

##### Relationships
|Entity Pair|Foreign Key|Business Rule|Type|Comments
|:---:|:---:|:---:|:---:|:---:|
|Category<br>&<br>Item|FK2||One-to-Many<br>Category / Item|This relationship represents that the items are of the Category|

#### Item
| Name | U | M | R | Data Type / Length | Valid Values | Default Values | Owner | Definition |
|:---|:---:|:---:|:---:|:---|:---:|:---:|:---:|:---|
|item_id|Y|Y|N|int|positive|auto-increment|database|Item Unique Identifier|
|item_name|Y|Y|N|string|Not zero length string|N/A|user|Name of the Item|
|quantity|N|Y|N|int|positive|1|user|Number of the items that are possessed|
|category_id|N|Y|N|int|See below|None|database|Category Unique Identifier of the Category of the Item|
|storage_container_id|N|Y|N|int|See below|NULL|database|Storage Container Unique Identifier of the Storage Container in which the Item belongs|
|in_use|N|Y|N|boolean|N/A|False|user|Whether or not the item is in-use i.e. not in the designated storage box|

##### Attribute Validation and Defaults
|Attribute Name|Validation|Default|Comments|
|:---:|:---:|:---:|:---|
|item_id||Auto-Incremented by Database||
|item_name|Length less 255 characters|N/A||
|quantity|Must be greater than 0|1||
|category_id|Must have a value in the Category list|||
|storage_container_id|Must have a value in the Storage Container list|||
|in_use||False||


##### Relationships
|Entity Pair|Foreign Key|Business Rule|Type|Comments
|:---:|:---:|:---:|:---:|:---:|
|Storage Container<br>&<br>Item|FK1||One-to-Many<br>Storage Container / Item|This relationship represents that the items are in the Storage Container|
|Category<br>&<br>Item|FK2||One-to-Many<br>Category / Item|This relationship represents that the items are of the Category|




