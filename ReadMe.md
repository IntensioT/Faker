**MPP SECOND TASK. FAKER**

Here is implemented an object generator with random test data.

When creating an object, you should use the constructor, and also fill in public fields and properties with public setters that were not filled in the constructor. Consider scenarios where a class has only a private constructor, multiple constructors, a constructor with parameters, and public fields/properties.
If there are multiple constructors, the one with more parameters should be preferred, but if an exception occurs while trying to use it, the others should be tried.
Note that user-defined value types, which are structures declared with the struct keyword, always have a parameterless constructor, but a user-defined constructor can be declared in addition to it (which should be tried first, guided by the logic of preference). constructor with many parameters).
The padding must be recursive (if the field is another object, then it must also be created using Faker).

Creating collections should be done in the same way as creating other types that have generators.
