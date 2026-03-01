import { createBrowserRouter } from 'react-router-dom';
import Layout from '../shared/components/Layout';
import Home from '../app/Home';
import Health from '../app/Health';

export const router = createBrowserRouter([
  {
    path: '/',
    element: <Layout />,
    children: [
      {
        index: true,
        element: <Home />,
      },
      {
        path: 'health',
        element: <Health />,
      },
    ],
  },
]);

