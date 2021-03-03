<template>
  <div class="keepsComponent card mb-2 imageFit" :data-target="'#keep-modal-'+keepProp.id" data-toggle="modal" :style="{backgroundImage:`url(${keepProp.img})`}">
    <h4>
      {{ keepProp.name }}
    </h4>
  </div>
  <!-- <button type="button" class="btn btn-primary" data-toggle="modal" :data-target="'#keep-modal-'+keepProp.id">
    Launch demo modal
  </button> -->
  <!-- Modal -->
  <div class="modal fade"
       :id="'keep-modal-'+keepProp.id"
       tabindex="-1"
       role="dialog"
       aria-labelledby="exampleModalLabel"
       aria-hidden="true"
  >
    <div class="modal-dialog" role="document">
      <div class="modal-content">
        <div class="modal-header">
          <h5 class="modal-title" id="exampleModalLabel">
            Modal title
          </h5>
          <button type="button" class="close" data-dismiss="modal" aria-label="Close">
            <span aria-hidden="true">&times;</span>
          </button>
        </div>
        <div class="modal-body">
          {{ keepProp.name }}
        </div>
        <div class="modal-footer">
          <button type="button" class="btn btn-secondary" data-dismiss="modal">
            Close
          </button>
          <button type="button" class="btn btn-primary">
            Save changes
          </button>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { reactive } from 'vue'
export default {
  name: 'KeepsComponent',
  props: {
    keepProp: { type: Object, required: true }
  },
  setup(props) {
    const state = reactive({

    })
    return { state }
  }
}
</script>

<style scoped>
.imageFit{
  height: 100%;
  width: 100%;
  object-fit: cover;
  }

</style>
