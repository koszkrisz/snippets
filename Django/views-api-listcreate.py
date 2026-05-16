# Django REST Framework ListCreateAPIView minta
# GET: listázás
# POST: új elem létrehozása

from rest_framework import generics
from .models import Project
from .serializers import ProjectSerializer


class ProjectListCreateView(generics.ListCreateAPIView):
    queryset = Project.objects.all()
    serializer_class = ProjectSerializer