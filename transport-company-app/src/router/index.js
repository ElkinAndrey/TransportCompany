import { Navigate } from 'react-router-dom';
import TransportsPage from './../components/pages/TransportsPage';

export const routes = [
  { path: "/", element: <Navigate to="/transport" />, exact: true },
  { path: "*", element: <Navigate to="/transport" />, exact: true },
  { path: "/transport", element: <TransportsPage />, exact: true },
];