import api from './api';

export const healthService = {
  check: async () => {
    const response = await api.get('/health');
    return response.data;
  },
};

