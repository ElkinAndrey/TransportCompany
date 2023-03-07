import { Navigate } from 'react-router-dom';
import PersonsPage from '../components/pages/PersonsPage';
import TransportsPage from './../components/pages/TransportsPage';

export const routes = [
  { path: "/", element: <Navigate to="/transport" />, exact: true },
  { path: "*", element: <Navigate to="/transport" />, exact: true },
  { path: "/transport", element: <TransportsPage />, exact: true },
  { path: "/person", element: <PersonsPage />, exact: true },
];