RMays.InfiniteCraft

I'm still not sure what I want this to do, or how it should work.

Goals:
- Given a word (ANY word), show how to create it efficiently using the 4 base values.
  - Example: input: "Volcano"; output: "Earth + Earth -> Mountain; Mountain + Fire -> Volcano"
  - Example: input: "Flberflizaw"; output: "No known path" (because the input word wasn't found)

Known questions:
- How do we store all the formulas (eg. "Earth + Earth -> Mountain")?
  - Text file: Can write all the known formulas.

Text file format (must be able to read and write):

Nothing: -1
Earth: 0
Fire: 1
Water: 2
Wind: 3
Mountain: 4

0+0:4
