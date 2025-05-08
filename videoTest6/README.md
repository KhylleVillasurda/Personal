
# 🎥 FCFS Scheduler with Integrated VLC Player

*A First-Come-First-Serve (FCFS) scheduling simulator with built-in video playback using LibVLC (NuGet).*  

![Demo Preview](https://github.com/KhylleVillasurda/Personal/blob/main/videoTest6/previewImage.jpg?raw=true)  

## 🔥 Key Features  
- **FCFS Algorithm Visualization** - Uses Gantt Chart as Visualization.
- **Seamless Video Playback** - Embedded VLC media player via `VideoLAN.LibVLC.Windows` NuGet package, although an unoptimized
  it's still a school project. :3
- **User Friendly** - A simple to navigate GUI to use the application wih ease.

## 🛠️ Tech Stack  
- `C#` | `.NET` | `LibVLC` | `Windows Forms`  

---

## 📥 Downloading
1. Copy this link: https://github.com/KhylleVillasurda/Personal/tree/main/videoTest6
2. Go to this website: https://download-directory.github.io/
3. Paste it onto its textbox.
4. if its zip, extract the file, or if its folder navigate through the folder to find the videoTest6.sln
5.If you found then open the program. Now its done!

## ![Usage](https://img.shields.io/badge/Usage-07DA63?style=flat)

### ⚡ Core Functions
| Element | Action | Icon |
|---------|--------|------|
| **Add Process** | Inserts new processes to the CellBox/Process Manager | 📥 |
| **Calculate Button** | Runs FCFS scheduling algorithm | ⚙️ |
| **Program Icon (Hidden)** | Click to reveal playback controls | 🕵️ |

### 🎥 Playback Controls (Hidden Feature)
1. **Click the program icon** (top-left corner)  
2. Reveals:  
   - ▶️ **Play/Pause**: Toggles video playback  
   - ⏭️ **Next**: Skips to next process in queue  

### 📋 Step-by-Step
1. **Add Processes**  
   ```C#
   Add Process name, arrival time then lastly burst time for the calculations.
   # Example input
   Process Name: "VideoRender", Arrival Time: 5, Burst Time: 4
   Process Name: "AudioMix", Arrival Time: 3, Burst Time: 10
   Then you can click Calculate!
