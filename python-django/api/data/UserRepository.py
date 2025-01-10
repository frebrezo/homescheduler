from ..models import User

from .UpdateResponse import UpdateResponse


class UserRepository:
    def get_users(self):
        return User.objects.all()

    def get_user(self, user_id):
        return User.objects.get(pk=user_id)

    def add_user(self, entity: User) -> UpdateResponse[User]:
        entity.save()
        return UpdateResponse(entity, 1)

    def update_user(self, user_id, entity: User) -> UpdateResponse[User]:
        existing_entity = User.objects.get(pk=user_id)
        if (existing_entity is None):
            return UpdateResponse(None, 0)

        existing_entity.username = entity.username
        existing_entity.firstname = entity.firstname
        existing_entity.lastname = entity.lastname
        existing_entity.updatedby = entity.updatedby
        existing_entity.updateddate = entity.updateddate

        existing_entity.save()
        return UpdateResponse(existing_entity, 1)
