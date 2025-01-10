from typing import Dict


class UserRequestDto:
    userName: str
    firstName: str
    lastName: str

    def __init__(self, userName: str, firstName: str, lastName: str) -> None:
        self.userName = userName
        self.firstName = firstName
        self.lastName = lastName

    def asdict(self):
        obj_dict = {}
        obj_dict.update({
            "userName": self.userName,
            "firstName": self.firstName,
            "lastName": self.lastName
        })
        return obj_dict

    @staticmethod
    def toobject(json_dict: Dict):
        dto = UserRequestDto(
            json_dict["userName"],
            json_dict["firstName"],
            json_dict["lastName"])
        return dto
