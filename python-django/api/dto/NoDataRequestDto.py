class NoDataRequestDto:
    updatedBy: str

    def __init__(self, updatedBy: str) -> None:
        self.updatedBy = updatedBy

    def asdict(self):
        obj_dict = {}
        obj_dict.update({
            "updatedBy": self.updatedBy
        })
        return obj_dict
