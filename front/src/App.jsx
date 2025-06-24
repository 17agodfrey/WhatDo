import { BrowserRouter, Routes, Route, Outlet } from 'react-router-dom';
import { AuthProvider } from './context/AuthProvider.jsx';
import PrivateRoute  from './routes/PrivateRoute.jsx';
import Navbar from './components/Navbar.jsx';
import LandingPage from './components/pages/LandingPage.jsx';
import MapSearchPage from './components/pages/MapSearchPage.jsx';
import NotFoundPage from './components/pages/NotFoundPage.jsx';
import AppStateProvider from './context/AppStateProvider.jsx';
import './styles/App.css'

function App() {
  return (
    <AuthProvider>
      <BrowserRouter>
          <Routes>
            {/* There should be a login page without the navbar */}
            {/* <Route path="/Login" element={<Login/>} />  */}
            
            {/* Layout route for pages that include the Navbar, wrapped with PrivateRoute */}
            <Route element={<AppStateProvider><LayoutWithNavbar /></AppStateProvider>}>
              <Route path="/" element={<LandingPage />} />
              <Route path="/map-search" element={<MapSearchPage />} />
              <Route path="*" element={<NotFoundPage />} />
            </Route>
          </Routes>
      </BrowserRouter>
    </AuthProvider>
  );
}

const LayoutWithNavbar = () => (
  // <div id='page-content'>
  <>
    <Navbar />
    <Outlet />
  </>
);

export default App;
