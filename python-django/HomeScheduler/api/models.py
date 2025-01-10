# This is an auto-generated Django model module.
# You'll have to do the following manually to clean this up:
#   * Rearrange models' order
#   * Make sure each model has one field with primary_key=True
#   * Make sure each ForeignKey and OneToOneField has `on_delete` set to the desired behavior
#   * Remove `managed = False` lines if you wish to allow Django to create, modify, and delete the table
# Feel free to rename the models, but don't rename db_table values or field names.
from django.db import models


class Availability(models.Model):
    availabilityid = models.AutoField(db_column='AvailabilityId', primary_key=True)  # Field name made lowercase.
    userid = models.OneToOneField('User', models.DO_NOTHING, db_column='UserId')  # Field name made lowercase.
    available = models.BooleanField(db_column='Available')  # Field name made lowercase.
    createdby = models.CharField(db_column='CreatedBy', max_length=256, db_collation='SQL_Latin1_General_CP1_CI_AS')  # Field name made lowercase.
    createddate = models.DateTimeField(db_column='CreatedDate')  # Field name made lowercase.
    updatedby = models.CharField(db_column='UpdatedBy', max_length=256, db_collation='SQL_Latin1_General_CP1_CI_AS')  # Field name made lowercase.
    updateddate = models.DateTimeField(db_column='UpdatedDate')  # Field name made lowercase.

    class Meta:
        managed = False
        db_table = 'Availability'


class User(models.Model):
    userid = models.AutoField(db_column='UserId', primary_key=True)  # Field name made lowercase.
    username = models.CharField(db_column='UserName', unique=True, max_length=128, db_collation='SQL_Latin1_General_CP1_CI_AS')  # Field name made lowercase.
    firstname = models.CharField(db_column='FirstName', max_length=256, db_collation='SQL_Latin1_General_CP1_CI_AS', blank=True, null=True)  # Field name made lowercase.
    lastname = models.CharField(db_column='LastName', max_length=256, db_collation='SQL_Latin1_General_CP1_CI_AS', blank=True, null=True)  # Field name made lowercase.
    createdby = models.CharField(db_column='CreatedBy', max_length=256, db_collation='SQL_Latin1_General_CP1_CI_AS')  # Field name made lowercase.
    createddate = models.DateTimeField(db_column='CreatedDate')  # Field name made lowercase.
    updatedby = models.CharField(db_column='UpdatedBy', max_length=256, db_collation='SQL_Latin1_General_CP1_CI_AS')  # Field name made lowercase.
    updateddate = models.DateTimeField(db_column='UpdatedDate')  # Field name made lowercase.

    class Meta:
        managed = False
        db_table = 'User'
