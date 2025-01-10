from typing import TypeVar, Type, Generic


T = TypeVar('T')


class PostResponseDto(Generic[T]):
    data: T
    changeCount: int = 0

    def __init__(self, data: T, changeCount: int) -> None:
        self.data = data
        self.changeCount = changeCount

    def asdict(self):
        obj_dict = {}
        if type(self.data) == list:
            obj_dict["data"] = list(map(lambda x: x.asdict(), self.data))
        else:
            obj_dict["data"] = self.data.asdict()
        obj_dict.update({
            "changeCount": self.changeCount
        })
        return obj_dict
