# ShadowMagicFlame - Documentation

**Version:** 1.0  
**Engine:** Unity 6.0+

## 🚀 WebGL Build

> Access the hosted WebGL version:

- 🎮 [Itch.io](https://kidkmon.itch.io/shadowmagicflame)

---

## 📋 Overview  
| Task | Description |
|------|-------------|
| **1 - Ace of Shadows** | Animated card stack system with dynamic counters and visual feedback. |
| **2 - Magic Words**    | Dialogue system with emoji support via API, dynamic loading, and custom formatting. |
| **3 - Phoenix Flame**  | Fire particle effect with toggle control and continuous color transition. |

---

## 🛠️ Architectures and Patterns  
### **Singleton**  
- Used for persist global components:
  - `LoadSceneManager`: responsible for the transition between scenes.
  - `FPSCounter`: responsible for track the FPS.

### **MVC (Model-View-Controller)**  
- **Model**: Data classes such as `DialogueData` and `AvatarData`.  
- **View**: UI elements and animations (e.g., `CardCounterUI`).  
- **Controller**: Business logic (e.g., `MessageManager`).  

---

## 🚀 How to Local Run  
1. Clone the repository.  
2. Open the project in **Unity 6.0+**.  
3. Navigate to `Scenes/MainMenuScene.unity`.  
4. Press **Play** in the Editor.  

---

## 🐞 Known Issues

- **Card stacking Z-order (Ace of Shadows)**  
  Occasionally, during fast transitions, the visual stacking of cards may briefly appear out of order due to transform hierarchy timing. Functionality is not affected.

- **Limited emoji set (Magic Words)**  
  Only a basic emoji set is currently supported via token parsing (`{emoji}`). Fallbacks for unknown tokens may not fully align with the intended emotion.

- **Click on screen doesn't complete current dialogue (Magic Words)**  

- **Gradient flickering (Phoenix Flame)**  
  On very low frame rates, gradient color transition on the fire may appear slightly jumpy. Smoothness depends on consistent update rates.

---

## 🚀 Future Work

- **Magic Words**
  - **Add typewriter animation to dialogues**  
    Gradual text reveal with optional user skip, to improve immersion.
  - **Emoji sprite atlas support**  
    Replace `{emoji}` tokens with actual sprite images to achieve full-color emoji rendering with TMP sprite assets.
  - **Dialogue skip and rewind**  
    Allow users to skip all messages or revisit previous ones in the Magic Words task.

- **General**
  - **Visual feedback on button states**  
    Add animations or hover effects to improve UI clarity and response.
  - **Audio feedback and ambient sounds**  
    Integrate SFX (e.g., fire crackle, UI clicks) for a richer player experience.
