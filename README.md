# Datasets
This repository contains datasets related to chemistry from various sources that uses permissive licenses, copyleft licenses, and the public domain/equivalents. The exhaustive list includes:
  - PubChem (maintained by National Center for Biotechnology Information, branch of the National Library of Medicine)
  - Wikimedia Foundation
    - Commons
    - English Wikipedia
    - Wikidata
  - [Bowserinator/Periodic-Table-JSON](https://github.com/Bowserinator/Periodic-Table-JSON)

This repository is free to use for your projects.

> This repository is a continuation of Bowserinator/Periodic-Table-JSON.
> Thank you to Bowserinator and the many [contributors](https://github.com/Bowserinator/Periodic-Table-JSON/graphs/contributors) for the work on this repository!

## Automation and source of truth
The primary, single source of truth is located in `/json/periodic-table.json`. A build script written in C# (under `src/`) uses this file to generate the following:
  - a JSON file of each itself, `/json/elements`, for use cases when you only need a single source. Each file's name follows the same format, which is `{zero-padded atomic number}-{element name}.json` (e.g `001-hydrogen.json`).
  - a minified version of the periodic table in `/json/periodic-table.min.json`.

### Running the build script
Currently, you will need to run it through Visual Studio.

#### In-progress tasks
  - Be able to run in a standalone terminal
  - Create a GitHub Actions workflow that will run this script

### Roadmap
  - [ ] Collect summaries through Wikipedia's REST API: `https://en.wikipedia.org/api/rest_v1/page/summary/{ElementName}`
  - [ ] Restructure JSON data to reorganize
  - [ ] JSON schema
  - [ ] Auto-export to XML and CSV

## Periodic table
  - Temperatures such as boiling points and melting points are given in degrees kelvin.
  - Densities are given in g/L and molar heat in (mol*K)
  - Information that is missing is represented as null. Some elements may have an image link to their spectral bands.
  - All elements have a three sentence summary from Wikipedia.
  - **Electron configuration** is given as a string, with each orbital separated by a space.
  - **Electron shells** are given as an array, the first item is the number of electrons in the first shell, the 2nd item is the number of electrons in the second shell, and so on.
  - Both **ionization energy** and **first electron affinities** are given as the energy required to *detach* an electron from the anion.  Ionization energies are given as an array for successive ionization energy.
  - A link to the source where the information was from is provided in each element under the key "source".

### Example
```json
[
	{
		"name": "Hydrogen",
		"appearance": "colorless gas",
		"atomic_mass": 1.008,
		"boil": 20.271,
		"category": "diatomic nonmetal",
		"density": 0.08988,
		"discovered_by": "Henry Cavendish",
		"melt": 13.99,
		"molar_heat": 28.836,
		"named_by": "Antoine Lavoisier",
		"number": 1,
		"period": 1,
		"phase": "Gas",
		"source": "https://en.wikipedia.org/wiki/Hydrogen",
		"spectral_img": "https://commons.wikimedia.org/wiki/File:Hydrogen_spectrum_visible.png",
		"summary": "Hydrogen is a chemical element with chemical symbol H and atomic number 1. With an atomic weight of 1.00794 u, hydrogen is the lightest element on the periodic table. Its monatomic form (H) is the most abundant chemical substance in the Universe, constituting roughly 75% of all baryonic mass.",
		"symbol": "H",
		"xpos": 1,
		"ypos": 1,
		"shells": [
			1
		],
		"electron_configuration": "1s1",
		"electron_affinity": 72.769,
		"electronegativity_pauling": 2.2,
		"ionization_energies": [
			1312
		]
	}
]
```

## License
### Software
The C# software is licensed under MIT<a href="#mit">[4]</a>.

### Data
  - **PubChem**: PubChem is licensed under ODbL (Open Data Commons Open Database License)()<a href="#odbl">[3]</a>.
  - **Wikimedia Commons**: Each element contains a link to a file hosted on Wikimedia Commons for their absorption spectrum. Each absorption spectrum file is licensed under CC0 1.0 (Creative Commons Universal Public Domain Dedication)<a href="#cc0-1.0">[1]</a>.
  - **English Wikipedia**: Data from the **English Wikipedia** is licensed under CC-BY-SA-3.0 (Creative Commons Attribution Share Alike 3.0 Unported)<a href="#cc-by-sa-3.0">[2]</a><a href="#wikipedia">[6]</a>.
  - **Wikidata**: Data from **Wikidata** is licensed under CC-1.0 (Creative Commons Universal Public Domain Dedication<a href="#cc0-1.0">[1]</a><a href="#wikidata">[5]</a>.

## References
1. <a name="cc0-1.0"></a> Creative Commons. (n.d.). CC0 1.0 Universal (CC0 1.0) Public Domain Dedication. Retrieved May 1, 2020, from https://creativecommons.org/publicdomain/zero/1.0/legalcode
2. <a name="cc-by-sa-3.0"></a> Creative Commons. (n.d.). Attribution-ShareAlike 3.0 Unported (CC BY-SA 3.0). Retrieved May 1, 2020, from https://creativecommons.org/licenses/by-sa/3.0/legalcode
3. <a name="odbl"></a> Open Database License (ODbL) v1.0. (2018, February 13). Retrieved from https://opendatacommons.org/licenses/odbl/1.0/
4. <a name="mit"></a> The MIT License. (n.d.). Retrieved May 1, 2020, from https://opensource.org/licenses/MIT
5. <a name="wikidata"></a> Wikidata contributors. (2017, August 2). Copyright. Retrieved May 1, 2020, from https://www.wikidata.org/wiki/Wikidata:Copyright
6. <a name="wikipedia"></a> Wikipedia contributors. (2019, January 26). Text of Creative Commons Attribution-ShareAlike 3.0 Unported License. Retrieved May 1, 2020, from https://en.wikipedia.org/wiki/Wikipedia:Text_of_Creative_Commons_Attribution-ShareAlike_3.0_Unported_License
