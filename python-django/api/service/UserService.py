import json
from datetime import datetime

from ..models import User
from ..data.UserRepository import UserRepository
from ..dto.RequestDto import RequestDto
from ..dto.UserDto import UserDto
from ..dto.UserRequestDto import UserRequestDto
from ..dto.UpdateResponseDto import UpdateResponseDto


class UserService:
    repo: UserRepository = UserRepository()

    def get_users(self):
        # https://stackabuse.com/map-filter-and-reduce-in-python-with-examples/
        result = list(map(lambda x: self.map_to_dto(x), self.repo.get_users()))
        return result

    def get_user(self, user_id):
        result = self.map_to_dto(self.repo.get_user(user_id))
        return result

    def add_user(self, dto: RequestDto[UserRequestDto]) -> UpdateResponseDto[UserDto]:
        entity = self.map_to_entity(dto)
        result = self.repo.add_user(entity)
        return UpdateResponseDto(self.map_to_dto(result.data), result.changeCount)

    def update_user(self, user_id, dto: RequestDto[UserRequestDto]):
        entity = self.map_to_entity(dto)
        result = self.repo.update_user(user_id, entity)
        return UpdateResponseDto(self.map_to_dto(result.data), result.changeCount)

    def map_to_dto(self, entity: User):
        return UserDto(
            userId=entity.userid,
            userName=entity.username,
            firstName=entity.firstname,
            lastName=entity.lastname,
            createdBy=entity.createdby,
            createdDate=entity.createddate,
            updatedBy=entity.updatedby,
            updatedDate=entity.updateddate)

    def map_to_entity(self, dto: RequestDto[UserRequestDto]):
        dt = datetime.utcnow()

        entity = User(
            username=dto.data.userName,
            firstname=dto.data.firstName,
            lastname=dto.data.lastName,
            createdby=dto.updatedBy,
            createddate=dt,
            updatedby=dto.updatedBy,
            updateddate=dt)
        return entity
