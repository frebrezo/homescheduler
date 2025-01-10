from django.urls import include, path
from rest_framework import routers

from . import views
from .viewsets import UserViewSet


#routers are not required when using direct mappings usings as_view().
urlpatterns = [
    #path("", views.index, name="index"),
    #path("user", views.get_users, name="get_users"),
    #path("user/<int:user_id>", views.get_user, name="get_user")
    path("user", UserViewSet.as_view({
        'get': 'get_all',
        'post': 'add_user'})),
    path("user/<int:user_id>", UserViewSet.as_view({
        'get': 'get_by_id',
        'put': 'update_user'}))
]
