from django.http import JsonResponse
from rest_framework import viewsets
from rest_framework.decorators import api_view
from rest_framework.response import Response

from .models import User
from .serializers import UserSerializer
from .service.UserService import UserService

from .dto.RequestDto import RequestDto
from .dto.GetResponseDto import GetResponseDto
from .dto.UserRequestDto import UserRequestDto
from .dto.PostResponseDto import PostResponseDto


class UserViewSet(viewsets.ViewSet):
    service: UserService = UserService()

    def get_all(self, request):
        data = self.service.get_users()
        response = GetResponseDto(data, len(data), len(data))
        return JsonResponse(response.asdict(), safe=False)

    def get_by_id(self, request, user_id):
        data = self.service.get_user(user_id)
        return JsonResponse(data.asdict(), safe=False)

    def add_user(self, request):
        dto = self.to_request_dto(request)
        result = self.service.add_user(dto)
        response = PostResponseDto(result.data, result.changeCount)
        return JsonResponse(response.asdict(), safe=False)

    def update_user(self, request, user_id):
        dto = self.to_request_dto(request)
        result = self.service.update_user(user_id, dto)
        response = PostResponseDto(result.data, result.changeCount)
        return JsonResponse(response.asdict(), safe=False)

    def to_request_dto(self, request):
        return RequestDto(
            UserRequestDto.toobject(request.data["data"]),
            request.data["updatedBy"])
