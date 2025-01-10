from django.shortcuts import render
from django.http import HttpResponse


# Not used for Django REST Framework.
# Create your views here.
def index(request):
    return HttpResponse("Hello, world. You're at the api index.")


def get_users(request):
    return HttpResponse("Hello, world. You're at the /api/user.")


def get_user(request, user_id):
    return HttpResponse(f"Hello, world. You're at the /api/user/{user_id}.")
