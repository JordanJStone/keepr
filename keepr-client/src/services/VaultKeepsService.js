// import { AppState } from '../AppState'
import { api } from './AxiosService'

class VaultKeepsService {
  async removeKeepFromVault(id) {
    console.log(id)
    if (confirm('Confirm deletion?')) { await api.delete('api/vaultkeeps/' + id) }
    // this.getNotes(note.bug)
  }

  async createVaultKeep(keep, newVaultId) {
    console.log(keep, newVaultId)
    await api.post('api/vaultkeeps', keep, newVaultId)
  }
}

export const vaultKeepsService = new VaultKeepsService()
