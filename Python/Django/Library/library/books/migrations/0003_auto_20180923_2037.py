# -*- coding: utf-8 -*-
# Generated by Django 1.11 on 2018-09-23 17:37
from __future__ import unicode_literals

from django.db import migrations, models
import django.db.models.deletion


class Migration(migrations.Migration):

    dependencies = [
        ('books', '0002_auto_20180923_2026'),
    ]

    operations = [
        migrations.RemoveField(
            model_name='author',
            name='first_name',
        ),
        migrations.RemoveField(
            model_name='book',
            name='description',
        ),
        migrations.AddField(
            model_name='book',
            name='author',
            field=models.ForeignKey(null=True, on_delete=django.db.models.deletion.CASCADE, to='books.Author'),
        ),
    ]