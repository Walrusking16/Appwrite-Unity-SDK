![Appwrite Unity SDK](https://assetstorev1-prd-cdn.unity3d.com/key-image/1bae5c90-ecaf-4390-b55e-bcb4a84006b1.jpg)

The Appwrite Unity SDK makes it easy to integrate your Unity app with the Appwrite API to start interacting with all
Appwrite features.

> **Note**
> Community made SDK, not affaliated with Appwrite

> **Warning**
> This SDK is still in beta and is not production ready. Please use with caution.

## Getting Started

### Add the SDK to your project

> **Note**
> Currently not on asset store

#### Using Unity Package Manager

1. Open your project in Unity
2. Open the Package Manager (Window > Package Manager)
3. Click the "+" button in the top left corner
4. Select "Add package from git URL..."
5. Paste the following URL: ```https://github.com/Walrusking16/Appwrite-Unity-SDK.git?path=AppwriteSDK```
6. Click "Add"
7. You're done!

#### Using the Unity Asset Store

1. Open your project in Unity
2. Open the Asset Store (Window > Asset Store)
3. Search for "Appwrite Unity SDK"
4. Click "Import"
5. You're done!

### Initialize the SDK

```csharp
var client = new AppwriteSDK.Client("endpoint", "projectid");
```

### Planned Features

- [ ] Documentation
- [ ] Examples
- [ ] Editor Tools
- [ ] Account
    - [ ] Create Account
    - [ ] Create Email Session
    - [ ] Create OAuth2 Session
    - [ ] Create Magic URL Session
    - [ ] Create Magic URL Session (Confirmation)
    - [ ] Create Phone Session
    - [ ] Create Phone Session (Confirmation)
    - [ ] Create Anonymous Session
    - [ ] Create JWT
    - [ ] Get Account
    - [ ] Get Account Preferences
    - [ ] List Sessions
    - [ ] List Logs
    - [ ] Get Session
    - [ ] Update Name
    - [ ] Update Password
    - [ ] Update Email
    - [ ] Update Phone
    - [ ] Update Preferences
    - [ ] Update Status
    - [ ] Delete Session
    - [ ] Update OAuth Session (Refresh Tokens)
    - [ ] Delete Sessions
    - [ ] Create Password Recovery
    - [ ] Create Password Recovery (Confirmation)
    - [ ] Create Email Verification
    - [ ] Create Email Verification (Confirmation)
    - [ ] Create Phone Verification
    - [ ] Create Phone Verification (Confirmation)
- [ ] Teams
    - [ ] Create Team
    - [ ] List Teams
    - [ ] Get Team
    - [ ] Update Team
    - [ ] Delete Team
    - [ ] Create Team Memberships
    - [ ] List Team Memberships
    - [ ] Get Team Membership
    - [ ] Update Membership Roles
    - [ ] Update Team Membership Status
    - [ ] Delete Team Membership
- [x] Database
    - [x] Create Document
    - [x] List Documents
    - [x] Get Document
    - [x] Update Document
    - [x] Delete Document
- [ ] Storage
    - [ ] Create File
    - [ ] List Files
    - [ ] Get File
    - [ ] Get File Preview
    - [ ] Get File for Download
    - [ ] Get File for View
    - [ ] Update File
    - [ ] Delete File
- [ ] Localization
    - [ ] Get User Locale
    - [ ] List Countries
    - [ ] List EU Countries
    - [ ] List Countries Phone Codes
    - [ ] List Continents
    - [ ] List Currencies
    - [ ] List Languages
- [ ] Avatars
    - [ ] Get Credit Card Icon
    - [ ] Get Browser Icon
    - [ ] Get Country Flag
    - [ ] Get Image from URL
    - [ ] Get Favicon
    - [ ] Get QR Code
    - [ ] Get User Initials
- [ ] Realtime
    - [ ] Connect
    - [ ] Subscribe
    - [ ] Unsubscribe
    - [ ] Publish
    - [ ] Disconnect
