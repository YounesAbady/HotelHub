Tables: 

- branches

	| Field Type | Field Name | Keys
	| --- | --- | --- |
	| Guid | Id | Primary Key |
	| string | BranchLocation |  |
	| string | BranchDescription |  |
	| string | BranchPhoneNumber |  |
	| string | BranchPictureURL |  |
	| List<rooms> | Rooms | Navigation Property |
	| List<rooms_branches> | BranchRooms | Navigation Property |
	| bool | IsActive |  |
	
- branch_pictures

	| Field Type | Field Name | Keys
	| --- | --- | --- |
	| Guid | Id | Primary Key |
	| Guid | BranchId | Foreign Key => (branches.Id) |
	| string | BranchPictureURL |  |
	| branches | Branch | Navigation Property |
	| bool | IsActive |  |

- rooms

	| Field Type | Field Name | Keys
	| --- | --- | --- |
	| Guid | Id | Primary Key |
	| string | RoomName |  |
	| double | Price |  |
	| int | Quantity |  |
	| room_type | RoomType | Navigation Property |
	| branch | Branch | Navigation Property |
	| List<rooms_pictures> | RoomPictures | Navigation Property |
	| bool | IsActive |  |

- rooms_types

	| Field Type | Field Name | Keys
	| --- | --- | --- |
	| Guid | Id | Primary Key |
	| string | RoomType |  |
	| string | RoomSize |  |
	| string | Beds |  |
	| string | Occupancy |  |
	| int | MaxCapacityAdults |  |
	| int | MaxCapacityChilds |  |
	| string | RoomDescription |  |
	| List<rooms> | Rooms | Navigation Property  |
	| bool | IsActive |  |

- rooms_pictures

	| Field Type | Field Name | Keys
	| --- | --- | --- |
	| Guid | Id | Primary Key |
	| Guid | RoomId | Foreign Key => (rooms.Id) |
	| string | RoomPictureURL |  |
	| rooms | Room | Navigation Property |
	| bool | IsActive |  |

- admins

	| Field Type | Field Name | Keys
	| --- | --- | --- |
	| Guid | Id | Primary Key |
	| string | Username |  |
	| string | HashedPassword |  |
	| bool | IsActive |  |

- reservations

	| Field Type | Field Name | Keys
	| --- | --- | --- |
	| Guid | Id | Primary Key |
	| Guid | BranchId | Foreign Key => (branches.Id) |
	| date | StartDate |  |
	| date | EndDate |  |
	| double | TotalPrice |  |
	| List<reserved_rooms> | ReservedRooms | Navigation Property  |
	| branches | Branch | Navigation Property  |
	| bool | IsActive |  |

- reserved_rooms

	| Field Type | Field Name | Keys
	| --- | --- | --- |
	| Guid | Id | Primary Key |
	| Guid | ReservedRoomId | Foreign Key => (rooms.Id) |
	| Guid | ReservationId | Foreign Key => (reservations.Id) |
	| double | RoomPrice |  |
	| reservations | Reservation | Navigation Property |
	| rooms | Room | Navigation Property |
	| bool | IsActive |  |

Relationships:

| Relation Type | Tables Involved 
| --- | --- |
| One to Many | branches to branch_pictures |
| One to Many | rooms to rooms_pictures |
| One to Many | branches to rooms |
| One to Many | room_type to rooms |
| One to Many | reservations to reserved_rooms |
