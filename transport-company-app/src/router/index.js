import { Navigate } from 'react-router-dom';
import PersonsPage from '../components/pages/PersonsPage';
import TransportsPage from './../components/pages/TransportsPage';
import RegionsPage from './../components/pages/RegionsPage';
import RegionPage from './../components/pages/RegionPage';
import WorkshopPage from './../components/pages/WorkshopPage';
import BrigadePage from '../components/pages/BrigadePage';
import PersonPage from './../components/pages/PersonPage';
import TransportPage from './../components/pages/TransportPage';
import AllTransportsPage from '../components/pages/AllTransportsPage';

export const routes = [
  { path: "/", element: <Navigate to="/transport" />, exact: true },
  { path: "*", element: <Navigate to="/transport" />, exact: true },
  { path: "/transport", element: <TransportsPage />, exact: true },
  { path: "/transport/:transportId", element: <TransportPage />, exact: true },
  { path: "/alltransport", element: <AllTransportsPage />, exact: true },
  { path: "/person", element: <PersonsPage />, exact: true },
  { path: "/person/:personId", element: <PersonPage />, exact: true },
  { path: "/region", element: <RegionsPage />, exact: true },
  { path: "/region/:regionId", element: <RegionPage />, exact: true },
  { path: "/workshop/:workshopId", element: <WorkshopPage />, exact: true },
  { path: "/brigade/:brigadeId", element: <BrigadePage />, exact: true },
];