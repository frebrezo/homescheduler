from typing import TypeVar, Type, Generic

T = TypeVar('T')


class GetResponseDto(Generic[T]):
    data: T
    count: int = 0
    pageSize: int

    def __init__(self, data: T, count: int, pageSize: int) -> None:
        self.data = data
        self.count = count
        self.pageSize = pageSize

    def asdict(self):
        obj_dict = {}
        if type(self.data) == list:
            obj_dict["data"] = list(map(lambda x: x.asdict(), self.data))
        else:
            obj_dict["data"] = self.data.asdict()
        obj_dict.update({
            "count": self.count,
            "pageSize": self.pageSize
        })
        return obj_dict
