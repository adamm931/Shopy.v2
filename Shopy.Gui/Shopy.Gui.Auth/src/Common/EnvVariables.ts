const ReadVariable = (name: string): string => process.env[name] || ""

export const AdminUrlEnv = ReadVariable('REACT_APP_ADMIN_URL')