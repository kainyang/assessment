import Navbar from './components/Navbar';
import { BrowserRouter, Route, Routes, Navigate } from 'react-router-dom';
import Employee from './components/Employee';
import CreateEditEmployee from './components/CreateEditEmployee';

function App() {
  return (
    <div className="content">
      <BrowserRouter>
        <Navbar />
        <Routes>
          <Route path='*' element={<Navigate to='employee/list' />} />
          <Route path='/employee/list' element={<Employee />} />
          <Route path='/employee/add' element={<CreateEditEmployee />} />
          <Route path='employee/edit/:id' element={<CreateEditEmployee />} />
        </Routes>
      </BrowserRouter>
    </div>
  );
}

export default App;
