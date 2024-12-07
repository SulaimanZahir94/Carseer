## Vehicle Selector Application

This project is a **Vehicle Selector Application** built using **ASP.NET Core 6** for the backend and **jQuery/JavaScript** for the front-end. The application integrates with the [NHTSA Vehicle API](https://vpic.nhtsa.dot.gov) to fetch real-time data for car makes, vehicle types, and models, offering a dynamic and user-friendly interface for users to explore and select vehicles.

### Features

#### **1. Dynamic Data Fetching**
- Fetches over 11,000 car makes, vehicle types, and models using the [NHTSA API](https://vpic.nhtsa.dot.gov).
- Handles large datasets efficiently with **local caching** and dynamic filtering.

#### **2. Optimized Performance**
- Utilizes `IMemoryCache` for server-side caching to reduce external API calls.
- Employs `localStorage` on the client-side to minimize repeated fetch requests and improve responsiveness.

#### **3. User-Friendly Interface**
- **Searchable Dropdowns**: Integrates **Select2** for enhanced dropdown functionality, allowing users to search and select car makes, vehicle types, and models easily.
- **Lazy Loading**: Dropdowns dynamically load data based on user selections, ensuring a seamless experience even with large datasets.

#### **4. Scalability**
- Designed to handle extensive datasets and concurrent users efficiently.
- Uses a modular and maintainable architecture for future enhancements.

#### **5. Real-World Integration**
- Leverages the [VPIC API](https://vpic.nhtsa.dot.gov) for live vehicle data, ensuring up-to-date information.

---

### Technology Stack

#### **Backend**
- **ASP.NET Core 6**: Provides a robust and scalable back-end framework.
- **C#**: Used for controller logic and API integration.
- **HttpClient**: Handles external API calls.
- **IMemoryCache**: Reduces redundant API calls with server-side caching.

#### **Frontend**
- **HTML5/CSS3**: Builds a clean and responsive interface.
- **JavaScript/jQuery**: Manages dynamic interactions and AJAX calls.
- **Select2**: Enhances dropdown functionality for better user experience.

---

### Installation and Setup

#### **Prerequisites**
- .NET SDK 6.0 or later
- Visual Studio or any IDE supporting .NET Core
- A modern browser (Chrome, Edge, Firefox)

#### **Steps to Run**
1. Clone the repository:
   ```bash
   git clone https://github.com/your-repo/vehicle-selector.git
   ```
2. Navigate to the project folder:
   ```bash
   cd vehicle-selector
   ```
3. Install dependencies and restore the project:
   ```bash
   dotnet restore
   ```
4. Run the project:
   ```bash
   dotnet run
   ```
5. Access the application in your browser:
   ```
   https://localhost:5001
   ```

---

### API Endpoints

1. **Get All Makes**
   - **Endpoint**: `/Home/GetAllMakes`
   - **Description**: Retrieves all available car makes with caching for efficiency.

2. **Get Vehicle Types**
   - **Endpoint**: `/Home/GetVehicleTypes`
   - **Parameters**:
     - `makeId` (int): The ID of the car make.
   - **Description**: Retrieves all vehicle types for a specific make.

3. **Get Models**
   - **Endpoint**: `/Home/GetModels`
   - **Parameters**:
     - `makeId` (int): The ID of the car make.
     - `year` (int): The manufacture year.
     - `vehicleType` (string): The vehicle type name.
   - **Description**: Retrieves all models for a specific make, year, and vehicle type.

---

### Screenshots

#### **1. Vehicle Selector Interface**
<img width="452" alt="image" src="https://github.com/user-attachments/assets/ead2973a-6b4f-4199-8ce8-5e9a7fae1add">

#### **2. Searchable Dropdowns**
<img width="433" alt="image" src="https://github.com/user-attachments/assets/151f2cfe-6b3e-4b1f-8680-2718b847e125">

---

### Future Enhancements

1. **Authentication**: Add user authentication to personalize the experience.
2. **Pagination**: Implement pagination for dropdowns with large datasets.
3. **Dark Mode**: Add a theme toggle for better user experience.
4. **Mobile Optimization**: Fully optimize the interface for mobile devices.

---

### Contributions

Contributions are welcome! To contribute:
1. Fork the repository.
2. Create a new branch.
3. Submit a pull request with detailed information about the changes.

---

### License

This project is licensed under the [MIT License](LICENSE).

---
