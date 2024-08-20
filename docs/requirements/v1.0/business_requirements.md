# Business Requirements
## Business Process Requirements
### Process Decomposition Diagram
![Process Decomposition Diagram](process_decomposition_diagram.svg)
### Process List
<ol>
	<li>Track Storage Containers</li>
	<ol>
		<li>[Add a Storage Container](#### Add a Storage Container)</li>
		<li>Edit a Storage Container</li>
		<li>List Storage Containers</li>
		<li>Get Storage Container Details</li>
		<li>Delete a Storage Container</li>
	</ol>
	<li>Track Categories</li>
	<ol>
		<li>Add a Category</li>
		<li>Edit a Category</li>
		<li>List Categories</li>
		<li>Get Category Details</li>
		<li>Delete a Category</li>
	</ol>
	<li>Track Items</li>
	<ol>
		<li>Add an Item</li>
		<li>Edit an Item</li>
		<li>List Items</li>
		<li>Get Item Details</li>
		<li>Delete a Item</li>
	</ol>
</ol>

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
||||

**Additional notes:** 

**Information source:** 
___
#### Edit a Storage Container
**Process ID:** BP1ii

**Detailed Description:** 

**External Agents Involved:** User

**What causes the process to occur?:** 

**What happens after the process is complete?:** 

**Business rules:** 

| Data Attributes | CRUD | Source
|:---|:---:|:---|
||||

**Additional notes:** 

**Information source:** 
___
#### List Storage Containers
**Process ID:** BP1iii

**Detailed Description:** This returns a list of all Storage Containers

**External Agents Involved:** User

**What causes the process to occur?:** 

**What happens after the process is complete?:** 

**Business rules:** 

| Data Attributes | CRUD | Source
|:---|:---:|:---|
||||

**Additional notes:** 

**Information source:** 
___
#### Get Storage Container Details
**Process ID:** BP1iv

**Detailed Description:** 

**External Agents Involved:** User

**What causes the process to occur?:** 

**What happens after the process is complete?:** 

**Business rules:** 

| Data Attributes | CRUD | Source
|:---|:---:|:---|
||||

**Additional notes:** 

**Information source:** 
___
#### Delete a Storage Container
**Process ID:** BP1v

**Detailed Description:** Remove the Storage Container record.  Update any items in the Storage Container and make them no longer in a container.

**External Agents Involved:** User

**What causes the process to occur?:** The user requests to delete the record.

**What happens after the process is complete?:** 

**Business rules:** 

| Data Attributes | CRUD | Source
|:---|:---:|:---|
||||

**Additional notes:** 

**Information source:** 
___
#### Add a Category
**Process ID:** BP2i

**Detailed Description:** Add a new Category record.  

**External Agents Involved:** User

**What causes the process to occur?:** 

**What happens after the process is complete?:** 

**Business rules:** 

| Data Attributes | CRUD | Source
|:---|:---:|:---|
||||

**Additional notes:** 

**Information source:** 
___
#### Edit a Category
**Process ID:** BP2ii

**Detailed Description:** 

**External Agents Involved:** User

**What causes the process to occur?:** 

**What happens after the process is complete?:** 

**Business rules:** 

| Data Attributes | CRUD | Source
|:---|:---:|:---|
||||

**Additional notes:** 

**Information source:** 
___
#### List Categories
**Process ID:** BP2iii

**Detailed Description:** This returns a list of all Categories

**External Agents Involved:** User

**What causes the process to occur?:** 

**What happens after the process is complete?:** 

**Business rules:** 

| Data Attributes | CRUD | Source
|:---|:---:|:---|
||||

**Additional notes:** 

**Information source:** 
___
#### Get Category Details
**Process ID:** BP2iv

**Detailed Description:** 

**External Agents Involved:** User

**What causes the process to occur?:** 

**What happens after the process is complete?:** 

**Business rules:** 

| Data Attributes | CRUD | Source
|:---|:---:|:---|
||||

**Additional notes:** 

**Information source:** 
___
#### Delete a Category
**Process ID:** BP2v

**Detailed Description:** Remove the Category record.  This request requires that the user designate a new category that all items in the category, being deleted, are updated with the new category.

**External Agents Involved:** User

**What causes the process to occur?:** The user requests to delete the record.

**What happens after the process is complete?:** 

**Business rules:** 

| Data Attributes | CRUD | Source
|:---|:---:|:---|
||||

**Additional notes:** 

**Information source:** 
___
#### Add an Item
**Process ID:** BP3i

**Detailed Description:** Add a new Item record.  

**External Agents Involved:** User

**What causes the process to occur?:** 

**What happens after the process is complete?:** 

**Business rules:** 

| Data Attributes | CRUD | Source
|:---|:---:|:---|
||||

**Additional notes:** 

**Information source:** 
___
#### Edit an Item
**Process ID:** BP3ii

**Detailed Description:** 

**External Agents Involved:** User

**What causes the process to occur?:** 

**What happens after the process is complete?:** 

**Business rules:** 

| Data Attributes | CRUD | Source
|:---|:---:|:---|
||||

**Additional notes:** 

**Information source:** 
___

#### List All Items
**Process ID:** BP3iii

**Detailed Description:** This returns a list of all Items

**External Agents Involved:** User

**What causes the process to occur?:** 

**What happens after the process is complete?:** 

**Business rules:** 

| Data Attributes | CRUD | Source
|:---|:---:|:---|
||||

**Additional notes:** 

**Information source:** 
___

#### Get Item Details
**Process ID:** BP3iv

**Detailed Description:** 

**External Agents Involved:** User

**What causes the process to occur?:** 

**What happens after the process is complete?:** 

**Business rules:** 

| Data Attributes | CRUD | Source
|:---|:---:|:---|
||||

**Additional notes:** 

**Information source:** 
___
#### Delete a Item
**Process ID:** BP3v

**Detailed Description:** Remove the Item record.

**External Agents Involved:** User

**What causes the process to occur?:** The user requests to delete the record.

**What happens after the process is complete?:** 

**Business rules:** 

| Data Attributes | CRUD | Source
|:---|:---:|:---|
||||

**Additional notes:** 

**Information source:** 
___

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
___


## Business Data Requirements
### Entities

| ID | Entity Name | Unique Identifier | Number of Occurances | Owner |
|:---:|:---|:---|:---:|:---|
|||||


### Entity Relationship Diagram
![Entity Relationship Diagram](entity_relationship_diagram.svg)
### Entity Details

#### Storage Container
| Name | U | M | R | Data Type / Length | Valid Values | Default Values | Owner | Definition |
|:---|:---:|:---:|:---:|:---|:---:|:---:|:---:|:---|
|storage_container_id|Y|Y|N|int|positive|auto-increment|database|Storage Container Unique Identifier|
|storage_container_name|Y|N|N|string|Any|NULL|user|Name of the Storage Container|
|storage_container_label|Y|Y|N|string|Any|N/A|user|Label on the Storage Container|


#### Category
| Name | U | M | R | Data Type / Length | Valid Values | Default Values | Owner | Definition |
|:---|:---:|:---:|:---:|:---|:---:|:---:|:---:|:---|
|category_id|Y|Y|N|int|positive|auto-increment|database|Category Unique Identifier|
|category_name|Y|Y|N|string|Not zero length string|N/A|user|Name for the Category|

#### Item
| Name | U | M | R | Data Type / Length | Valid Values | Default Values | Owner | Definition |
|:---|:---:|:---:|:---:|:---|:---:|:---:|:---:|:---|
|item_id|Y|Y|N|int|positive|auto-increment|database|Item Unique Identifier|
|item_name|Y|Y|N|string|Not zero length string|N/A|user|Name of the Item|
|quantity|N|Y|N|int|positive|1|user|Number of the items that are possessed|
|category_id|N|Y|N|int|Have a matching value in the category list|None|database|Category Unique Identifier of the Category of the Item|
|storage_container_id|N|Y|N|int|Have a matching value in the storage container list|NULL|database|Storage Container Unique Identifier of the Storage Container in which the Item belongs|
|in_use|N|Y|N|boolean|N/A|False|user|Whether or not the item is in-use i.e. not in the designated storage box|

### Valid Values/Default Values

### Relationships

