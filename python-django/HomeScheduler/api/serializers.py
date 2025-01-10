from rest_framework import serializers

from .models import User, Availability


# Not used when using DTOs. Serializer is used to serialize Django entities.
class UserSerializer(serializers.HyperlinkedModelSerializer):
    class Meta:
        model = User
        fields = ['userid', 'username', 'firstname', 'lastname', 'createdby', 'createddate', 'updatedby', 'updateddate']


class AvailabilitySerializer(serializers.HyperlinkedModelSerializer):
    class Meta:
        model = Availability
        fields = ['availabilityid', 'userid', 'available', 'createdby', 'createddate', 'updatedby', 'updateddate']
