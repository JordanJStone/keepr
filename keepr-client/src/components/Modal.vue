<template>
  <div class="QuickModal">
    <!-- Modal -->
    <div class="modal fade"
         id="modelId"
         tabindex="-1"
         role="dialog"
         aria-labelledby="modelTitleId"
         aria-hidden="true"
    >
      <div class="modal-dialog" role="document">
        <div class="modal-content">
          <div class="modal-header">
            <h5 class="modal-title">
              Modal title
            </h5>
            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
              <span aria-hidden="true">&times;</span>
            </button>
          </div>
          <div class="modal-body">
          </div>
          <div class="modal-footer">
            <button type="button" class="btn btn-secondary" data-dismiss="modal">
              Close
            </button>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { logger } from '../utils/Logger'
import { reactive } from 'vue'
import { keepsService } from '../services/KeepsService'
export default {
  name: 'QuickModal',
  setup() {
    const state = reactive({
      activeKeep: {}
    })
    return {
      state,
      async getKeep() {
        try {
          await keepsService.getKeeps(state.activeKeep)
        } catch (error) {
          logger.error(error)
        }
      }
    }
  }
}
</script>

<style scoped>
</style>
