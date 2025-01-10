from datetime import datetime


class UserDto:
    userId: int
    userName: str
    firstName: str
    lastName: str
    createdBy: str
    createdDate: datetime
    updatedBy: str
    updatedDate: datetime

    def __init__(self, **kwargs) -> None:
        self.userId = kwargs["userId"]
        self.userName = kwargs["userName"]
        self.firstName = kwargs["firstName"]
        self.lastName = kwargs["lastName"]
        self.createdBy = kwargs["createdBy"]
        self.createdDate = kwargs["createdDate"]
        self.updatedBy = kwargs["updatedBy"]
        self.updatedDate = kwargs["updatedDate"]

    def asdict(self):
        obj_dict = {}
        if hasattr(self, "userId"):
            obj_dict["userId"] = self.userId
        obj_dict.update({
            "userName": self.userName,
            "firstName": self.firstName,
            "lastName": self.lastName,
            "createdBy": self.createdBy,
            "createdDate": self.createdDate,
            "updatedBy": self.updatedBy,
            "updatedDate": self.updatedDate
        })
        return obj_dict
