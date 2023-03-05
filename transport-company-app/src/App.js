import { React } from "react";
import AppRouter from './components/pages/AppRouter';
import { BrowserRouter } from 'react-router-dom';
import "./App.css";

function App() {
  return (
    <div>
      <BrowserRouter>
        <AppRouter />
      </BrowserRouter>
    </div>
  );
}

export default App;
