### MileageTrackerMobile

Modern cross‑platform mileage tracking app built with Avalonia and .NET 9. Run it on Desktop (Windows/macOS/Linux), Android, and iOS from a single codebase using MVVM.

#### Highlights
- Single UI codebase with Avalonia UI and MVVM
- Targets: `net9.0` (Desktop), `net9.0-android`, `net9.0-ios`
- Clean, minimal login/registration flow based on a simple session ID
- Theming and custom styles with `AppDefaultStyles.axaml`

---

### Screens
- Home: Register or Log in using a numeric User ID
- On successful registration, your new session ID flashes briefly for convenience
- Friendly feedback on invalid or unknown session IDs

> Tip: The UI you see is defined in `MileageTrackerMobile/Views/MainView.axaml` with logic in `MainView.axaml.cs` and `ViewModels/MainViewModel.cs`.

---

### Tech Stack
- .NET 9
- Avalonia UI (XAML)
- MVVM pattern (`ViewModels`, `Views`, `Models`)
- Multi‑target solution with platform heads:
  - `MileageTrackerMobile.Desktop`
  - `MileageTrackerMobile.Android`
  - `MileageTrackerMobile.iOS`

---

### Project Structure (high level)
```
MileageTrackerMobile.sln
├─ MileageTrackerMobile/                 # Shared app (Views, ViewModels, Models, Styles)
│  ├─ Views/                             # XAML views (e.g., MainView.axaml)
│  ├─ ViewModels/                        # ViewModels (e.g., MainViewModel.cs)
│  ├─ Models/                            # Domain models (e.g., Session.cs)
│  ├─ Assets/                            # Fonts and other assets
│  ├─ App.axaml                          # App resources
│  └─ AppDefaultStyles.axaml             # Theming/styling
├─ MileageTrackerMobile.Desktop/         # Desktop head (net9.0)
├─ MileageTrackerMobile.Android/         # Android head (net9.0-android)
└─ MileageTrackerMobile.iOS/             # iOS head (net9.0-ios)
```

Key classes you may want to explore:
- `Views/MainView.axaml` and `MainView.axaml.cs` — login/register UI and handlers
- `ViewModels/MainViewModel.cs` — UI state, binding properties (e.g., `HomepageVisible`, `LoginInput`)
- `Models/Session.cs` — session model
- `APIController.cs` — async API helpers for creating/fetching sessions

---

### Getting Started

#### Prerequisites
- .NET SDK 9.0+
- IDE: Rider, Visual Studio 2022+, or VS Code
- For Android: Android SDK + `dotnet workload install android`
- For iOS: Xcode + `dotnet workload install ios` (build/deploy from macOS)

> If you are only trying the Desktop app, you only need the .NET SDK.

#### Clone
```
git clone https://github.com/Mileage-Tracker-App/MileageTrackerMobile.git
cd MileageTrackerMobile
```

#### Restore
```
dotnet restore
```

#### Run (Desktop)
```
dotnet run --project MileageTrackerMobile.Desktop
```

#### Run (Android)
Use your IDE (Rider/Visual Studio) to select the `MileageTrackerMobile.Android` project and deploy to an emulator or device. Or via CLI:
```
dotnet build MileageTrackerMobile.Android -c Debug
```

#### Run (iOS)
On macOS with Xcode and iOS workload installed. Use your IDE to deploy `MileageTrackerMobile.iOS` to a simulator/device. Or via CLI:
```
dotnet build MileageTrackerMobile.iOS -c Debug
```

---

### Configuration
The app demonstrates a simple session‑based auth flow. API operations are wrapped in `APIController`:
- `CreateSessionAsync<TSession>()` — creates a new session and returns an ID
- `GetSessionAsync<TSession>(id)` — retrieves an existing session by ID

If your API requires a base URL or keys, add/update configuration in `APIController.cs` or wire it via DI according to your environment.

---

### Development Notes
- UI state flags: `HomepageVisible`, `SessionIdDisplayVisible`, `SessionNotExistVisible`
- Input binding: `LoginInput`
- After registering, the app temporarily shows the assigned `SessionID` for 2 seconds
- Login validates numeric input and fetches an existing session; otherwise shows a helpful message

---

### Contributing
Contributions are welcome!
1. Fork the repo
2. Create a feature branch: `git checkout -b feature/your-feature`
3. Commit your changes: `git commit -m "feat: add your feature"`
4. Push the branch: `git push origin feature/your-feature`
5. Open a Pull Request

Please follow the existing code style and MVVM patterns.

---

### Roadmap Ideas
- Persist trips and mileage entries per session
- Cloud sync/back‑end integration and offline cache
- Export to CSV/Excel
- Map integration for route distance
- Theming options (light/dark/system)

---

### License
This project uses the [GNU GPL V3](https://www.gnu.org/licenses/gpl-3.0.md)
