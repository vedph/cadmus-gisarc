# Cadmus GISARC Core

This is the core for the Cadmus GISARC project.

## Inscriptions

Inscription ID should be equal to ISiciliy ID.

General:

- external IDs\*: all the IDs linked to the inscription (ISicily and eventually others).
- metadata: general purpose metadata.
- [location](#location)\*
- date\*
- [epigraphic support](#episupport)
- [epigraphic writing](#epiwriting)

Classification:

- categories\*: general thematic tags from some taxonomy.
- index keywords: multiple-language keywords.

Comment:

- comment: generic comment.
- note: free text note. Might be useful for redactional purposes.

References:

- references: short documentary references.
- bibliography.

Text:

- text: text or a part of it when required.
- apparatus layer: critical apparatus.
- orthography layer: can be used to annotate and categorize linguistic phenomena reflected in orthography.
- comment layer: can be used to comment specific words of the text.

## Sites

Site ID is its title.

General:

- name(s)
- metadata
- external IDs

Comment:

- comment
- note

References:

- references
- bibliography

## New Models

### Location

- `latitude`\* (number)
- `longitude`\* (number)
- `altitude` (number, expressed in mt; optional)
- `geometries` (string[])

### EpiWriting

- `system` (string, thesaurus usually ISO 15924 lowercase)
- `type` (string, thesaurus)
- `technique` (string, thesaurus)
- `tool` (string, thesaurus)
- `frameType` (string, thesaurus)
- `counts` (DecoratedCount[]):
  - `id`\* (string)
  - `tag` (string)
  - `value`\* (number)
  - `note` (string)
- `figType` (string, thesaurus)
- `figFeatures` (string[], thesaurus)
- `scriptFeatures` (string[], thesaurus)
- `languages` (string[], usually ISO 639-3)
- `hasPoetry` (boolean)
- `metres` (string[])

### EpiSupport

- `material`\* (string, thesaurus: `epi-support-materials`)
- `originalFn` (string, thesaurus: `epi-support-functions`)
- `currentFn` (string, thesaurus: `epi-support-functions`)
- `objectType` (string, thesaurus: `epi-support-object-types`)
- `supportType` (string, thesaurus: `epi-support-types`)
- `indoor` (boolean)
- `size` (`PhysicalSize`):
  - `tag` (string, thesaurus: `physical-size-tags`)
  - `w` (PhysicalSize):
    - `value`\* (number)
    - `unit`\* (string, thesaurus: `physical-size-units`)
    - `tag` (string, thesaurus: `physical-size-dim-tags`)
  - `h` (PhysicalSize)
  - `d` (PhysicalSize)
  - `note` (string)
- `state` (string, thesaurus: `epi-support-states`)
- `lastSeen` (date)
