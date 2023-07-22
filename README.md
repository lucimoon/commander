# Commander

This is an exploration of the [command pattern](https://refactoring.guru/design-patterns/command) for use in Unity. It was written a long time ago and I've ported over the notes I left for myself. I initially built it as an approach to mapping player character behavior to different physical inputs, but the Input System released by Unity in 2019 thankfully made this obsolete even for my personal use.

## Notes

GOAL: Design a system of automatic controller commands
REQS:

- behaviour should be driven by environmental context
- if something (a box) is in the environment
  - and i see it
    - i may get it's list of interactions and select one
      - if i'm not within required interaction distance,
        - walk until i am
- Interactions
  - Controller for other Objs
- Behaviors

  - Controller for Autonomy
  - Controller for Player

- Inanimate Objs
  - Interactions
- Animate Objs

  - Interactions
  - Behaviors

- Animate Wave
  - Just an arm movement
- How to mask animation with Unity?
  - arm waving shouldn't interrupt walk

### SensoryOverride

- Can I decide to wave if i'm already walking?
  - Sensory Override
    - Happen at Commander Level
      - i.e. if(sensory override)StartCoroutine()
