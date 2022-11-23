# Cadmus GISARC Core

This is the core for the Cadmus GISARC project.

## Inscriptions

- external IDs: all the IDs linked to the inscription (ISicily and eventually others).
- metadata: general purpose metadata.
- categories: general thematic tags from some taxonomy.
- keywords: multiple-language keywords.
- comment: generic comment.
- note: free text note. Might be useful for redactional purposes.
- bibliography.

- text: text or a part of it when required.
- apparatus layer: critical apparatus.
- orthography layer: can be used to annotate and categorize linguistic phenomena reflected in orthography.
- comment layer: can be used to comment specific words of the text.

- epi support: see below.
- epi writing: see below.
- location: see below.

## Sites

Site ID is its title.

- name(s)
- metadata
- external IDs
- comment
- note
- bibliography part

## New Models

### Location

- latitude\* (number)
- longitude\* (number)
- altitude (number, mt, optional)
- geometries (string[])

### EpiWriting

- system (string, thesaurus usually ISO 15924 lowercase)
- type (string, thesaurus)
- technique (string, thesaurus)
- tool (string, thesaurus)
- frameType (string, thesaurus)
- counts (DecoratedCount[]):
  - id\* (string)
  - tag (string)
  - value\* (number)
  - note (string)
- figType (string, thesaurus)
- figFeatures (string[], thesaurus)
- scriptFeatures (string[], thesaurus)
- languages (string[], usually ISO 639-3)
- hasPoetry (boolean)
- metres (string[])

### EpiSupport

- originalFn (string, thesaurus)
- currentFn (string, thesaurus)
- objectType (string, thesaurus)
- supportType (string, thesaurus)
- material\* (string, thesaurus)
- indoor (boolean)
- size (PhysicalSize):
  - tag (string)
  - w (PhysicalSize):
    - value\* (number)
    - unit\* (string)
    - tag (string)
  - h (PhysicalSize)
  - d (PhysicalSize)
  - note (string)
- state (string, thesaurus)
- lastSeen (date)
