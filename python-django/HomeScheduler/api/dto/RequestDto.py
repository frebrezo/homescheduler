from typing import TypeVar, Type, Generic, Callable


T = TypeVar('T')


class RequestDto(Generic[T]):
    data: T
    updatedBy: str

    def __init__(self, data: T, updatedBy: str) -> None:
        self.data = data
        self.updatedBy = updatedBy

    def asdict(self):
        obj_dict = {}
        if type(self.data) == list:
            obj_dict["data"] = list(map(lambda x: x.asdict(), self.data))
        else:
            obj_dict["data"] = self.data.asdict()
        obj_dict.update({
            "updatedBy": self.updatedBy
        })
        return obj_dict
