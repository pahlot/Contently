# Contently
A simple, unopinionated .net core CMS

## What is it and who is it for?

The purpose of Contently is really self-serving. There are so many .NET Content Management Systems (CMS) out there, but the vast majority are quite opinionated with how you work with the CMS.
As a developer I find this exceedginly frustrating! How many times have you just wanted a CMS that you can "drop in" and it'll play nice with your existing app? Me too!!!

So I've taken apon myself to create a simple, performant and unopinionated CMS based on .NET Core. 

All features are based around .NET Core, templates are simply standard Razor Views! So if you want to have a template that has content that some from another controller or sub-system you just integrate it as you usually would. This also means that a change to any template will be reflected on your content managed pages as well (providing you're using the same templates), no longer do you have to manage the same template in multiple locations because you want to give you and/or your users the ability to content manage a site.

Still very much in its infancy (pre-alpha), but will hopefully be finished quickly.

NOTE: This CMS is designed for .NET developers, it's really not designed to replace any full-feature CMS.

## What works now?

- Routing (plays nice with exsting controllers and routes!)
- Handles 404 errors 

## What features are coming?

- Authentication & Authorization (I'm happy to accept some comments around how others might view the best way to integrate this, my present view is to have group based system with a polymorphic user that'll also be the base authentication/authorization system for future apps)
- Content editor
- Search (something severely missing in most CMS's!) 
- Extension to the membership system that'll include;
-- Paid memberships
-- Newsletter management 
- Maybe a basic plugin / extensibility feature that'll allow people to modify the platform

