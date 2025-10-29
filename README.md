# 🎮 Programming Theory Project

This is the final project of the **Unity Junior Programmer Pathway**.

## 🐾 Animal Day Care

Control a small environment where different animals move around freely. Click on them to view their information and animations.

## 📁 Project Overview

**Main Focus:**  
Apply and demonstrate the four fundamental OOP concepts in Unity:

1. **Abstraction** – Use higher-level methods to hide unnecessary details.

   - The MainGameUIHandler and SaveSystem hide complex logic behind simple public methods like ShowInfo() and Save(), allowing other scripts to interact with UI and data without needing to know the implementation details.

2. **Inheritance** – Create parent/child classes to share and extend functionality.

   - The Animal base class defines shared properties and methods for all animals, while child classes such as Cat, Dog, and Chicken extend it with their own behavior (e.g., unique sounds and data loading).

3. **Polymorphism** – Show method overriding or overloading in action.

   - Each animal overrides methods like OnAnimalClicked() and LoadData(), enabling different responses to the same base class calls depending on the animal type.

4. **Encapsulation** – Use getters and setters to safely expose private data.
   - Important data and object references (like UI elements and animal attributes) are kept private and accessed through getters or serialized fields, ensuring clean and controlled communication between classes.

## 💡 Future improvements

- Add indicator to selected animal
- Add and remove animals
- Add animal sounds
- Make animals chase each other
- Settings page

## 🛠 Unity Information

- **Unity Version:** 6.0 LTS (6000.0.60f1)
- **Render Pipeline:** Universal Render Pipeline (URP)

## 🤍 Credits

- [Garden cozy kit UI/GUI buttons and icons](https://mandinhart.itch.io/garden-cozy-kit-uigui-buttons-and-icons) by **Mandinhart**
- [Animals FREE - Animated Low Poly 3D Models](https://assetstore.unity.com/packages/3d/characters/animals/animals-free-animated-low-poly-3d-models-260727) by **ithappy**
- [Cozy Interiors: Demo Pack](https://assetstore.unity.com/packages/2d/textures-materials/building/cozy-interiors-demo-pack-322192) by **Shaded Spectrum**
- [Stylized House Interior](https://assetstore.unity.com/packages/3d/environments/stylized-house-interior-224331) by **StylArts**
